//using System;
using Microsoft.VisualBasic;
using System.IO;
using TileDB.CSharp;
using TileDB.CSharp.Examples;
namespace Examples
{
    class ExampleQuery
    {
        //private static readonly string arrayUri = $"gcs://drago-deps-bucket/array{System.Guid.NewGuid()}";
        private static readonly string arrayUri = ExampleUtil.MakeTempPath($"array{System.Guid.NewGuid()}");

        private const int CellVal = 1;
        protected static void CreateArray()
        {
            var context = Context.GetDefault();
            context.Config().Set("vfs.gcs.project_id", "edxt-dev-test");
            // Create array
            int[] dim1_bound = new int[] { 0, 2 };
            int dim1_extent = 3;
            var dim1 = Dimension.Create<int>(context, "rows", dim1_bound, dim1_extent);
            
            int[] dim2_bound = new int[] { 0, 2 };
            int dim2_extent = 3;
            var dim2 = Dimension.Create<int>(context, "cols", dim2_bound, dim2_extent);

            var domain = new Domain(context);
            domain.AddDimension(dim1);
            domain.AddDimension(dim2);

            var array_schema = new ArraySchema(context, ArrayType.Dense);

            var attr = new Attribute(context, "a", DataType.Int32);
            attr.SetCellValNum(CellVal);
            attr.SetFillValue(-7);

            array_schema.AddAttribute(attr);
            array_schema.SetDomain(domain);
            array_schema.Check();
            /*
            var tmpArrayPath = Path.Join(Path.GetTempPath(), "tiledb_example_sparse_array");

            if (Directory.Exists(tmpArrayPath))
            {
                Directory.Delete(tmpArrayPath, true);
            }
            */

            Array.Create(context, arrayUri, array_schema);

        } //protected void CreateArray()

        protected static void WriteArray()
        {
            WriteArray1(new int[4] { 0, 1, 0, 1 }, 0);
            ReadArray();
            WriteArray1(new int[4] { 1, 2, 0, 1 }, 1);
            ReadArray();
            WriteArray1(new int[4] { 0, 1, 1, 2 }, 2);
            ReadArray();
            WriteArray1(new int[4] { 1, 2, 1, 2 }, 3);
        }
        protected static void WriteArray1(int[] subarray, int val)
        {
            var context = Context.GetDefault();

            var attr_data_buffer = new int[CellVal * 4];

            for (int i = 0; i < attr_data_buffer.Length; i++)
            {
                attr_data_buffer[i] = val;
            }

            /*
            var attr_data_buffer = new int[]
            {
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
                3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
            };
            */

            /*
            var attr_data_buffer = new int[]
            {
                0, 1, 2, 3, 4,
            };
            */

            // NOTE: Subarray indices here are { rowMin, rowMax, colMin, colMax }
            // not { rowMin, colMin, rowMax, colMax }!
            //var subarray = new int[4] { 0, 1, 0, 1 };
            using (var array_write = new Array(context, arrayUri))
            {
                array_write.Open(QueryType.Write);
                var query_write = new Query(context, array_write);
                query_write.SetLayout(LayoutType.RowMajor);
                query_write.SetSubarray(subarray);
                query_write.SetDataBuffer("a", attr_data_buffer);
                query_write.Submit();
                var status = query_write.Status();
                array_write.Close();
            }//array_write

        }

        public static void ConsolidateArray()
        {
            System.DateTime start;
            System.Console.WriteLine($"Consolidating meta...");
            start = System.DateTime.Now;
            Context.GetDefault().Config().Set("sm.consolidation.mode", "fragment_meta");
            Array.Consolidate(Context.GetDefault(), arrayUri, Context.GetDefault().Config());
            System.Console.WriteLine($"{(System.DateTime.Now - start).TotalMilliseconds}ms Consolidated.");

            System.Console.WriteLine($"Consolidating commits...");
            start = System.DateTime.Now;
            Context.GetDefault().Config().Set("sm.consolidation.mode", "commits");
            Array.Consolidate(Context.GetDefault(), arrayUri, Context.GetDefault().Config());
            System.Console.WriteLine($"{(System.DateTime.Now - start).TotalMilliseconds}ms Consolidated.");

            System.Console.WriteLine($"Vacuuming...");
            start = System.DateTime.Now;
            Array.Vacuum(Context.GetDefault(), arrayUri);
            System.Console.WriteLine($"{(System.DateTime.Now - start).TotalMilliseconds}ms Vacuumed.");
        }

        protected static void ReadArray()
        {
            var context = Context.GetDefault();
            var tmpArrayPath = Path.Join(Path.GetTempPath(), "tiledb_example_sparse_array");
            //var attr_data_buffer_read = new int[40];
            var attr_data_buffer_read = new int[CellVal * 9];

            var subarray = new int[4] { 0, 2, 0, 2 };

            using (var array_read = new Array(context, arrayUri))
            {
                array_read.Open(QueryType.Read);
                var query_read = new Query(context, array_read);
                query_read.SetLayout(LayoutType.RowMajor);
                query_read.SetSubarray(subarray);
                query_read.SetDataBuffer<int>("a", attr_data_buffer_read);
                query_read.Submit();
                var status_read = query_read.Status();
                array_read.Close();
            }

            System.Console.WriteLine($"READ: {string.Join(", ", attr_data_buffer_read)}");
        }

        protected static void OnReadCompleted(object sender, QueryEventArgs args)
        {
            System.Console.WriteLine("Read completed!");
        }

        protected static void ReadArrayAsync()
        {
            var context = Context.GetDefault();
            var tmpArrayPath = Path.Join(Path.GetTempPath(), "tiledb_example_sparse_array");
            var dim1_data_buffer_read = new int[3];
            var dim2_data_buffer_read = new int[3];
            var attr_data_buffer_read = new int[3];

            var array_read = new Array(context, arrayUri);
            array_read.Open(QueryType.Read);
            var query_read = new Query(context, array_read);
            query_read.SetLayout(LayoutType.RowMajor);
            query_read.SetDataBuffer<int>("rows", dim1_data_buffer_read);
            query_read.SetDataBuffer<int>("cols", dim2_data_buffer_read);
            query_read.SetDataBuffer<int>("a", attr_data_buffer_read);
            query_read.QueryCompleted += OnReadCompleted!;
            query_read.SubmitAsync();
        }

        public static void ReadFragments()
        {
            using var fi = new FragmentInfo(Context.GetDefault(), arrayUri);
            fi.Load();
            System.Console.WriteLine($"Fragments: {fi.FragmentCount}");
            System.Console.WriteLine($"Cells: {fi.TotalCellCount}");
            System.Console.WriteLine($"Unconsolidated meta: {fi.FragmentWithUnconsolidatedMetadataCount}");
            System.Console.WriteLine($"Unvacuumed: {fi.FragmentToVacuumCount}");

            for (uint i = 0; i < fi.FragmentCount; i++)
            {
                System.Console.WriteLine();
                System.Console.WriteLine($"Fragment {i}:");
                System.Console.WriteLine($"Size {fi.GetFragmentSize(i)}");
                System.Console.WriteLine($"Domain0 {fi.GetNonEmptyDomain<int>(i, 0)}");
                System.Console.WriteLine($"Domain1 {fi.GetNonEmptyDomain<int>(i, 1)}");
                (ulong start, ulong end) = fi.GetTimestampRange(i);
                ReadFragmentData(start, end);
            }
        }

        public static void ReadFragmentData(ulong start, ulong end)
        {
            var context = Context.GetDefault();

            var attr_data_buffer_read = new int[CellVal];

            var subarray = new int[4] { 1, 1, 1, 1 };

            using (var array_read = new Array(context, arrayUri))
            {
                array_read.SetOpenTimestampStart(start);
                array_read.SetOpenTimestampEnd(end);

                array_read.Open(QueryType.Read);
                var query_read = new Query(context, array_read);
                query_read.SetLayout(LayoutType.RowMajor);
                query_read.SetSubarray(subarray);
                query_read.SetDataBuffer<int>("a", attr_data_buffer_read);
                query_read.Submit();
                var status_read = query_read.Status();
                array_read.Close();
            }

            System.Console.WriteLine($"READ: {string.Join(", ", attr_data_buffer_read)}");
        }

        public static void Run()
        {
            System.Console.WriteLine(arrayUri);
            CreateArray();
            //CreateArray();
            WriteArray();
            ConsolidateArray();
            ReadArray();
            //ReadArrayAsync();
            ReadFragments();
        }
    }//class
}//namespace