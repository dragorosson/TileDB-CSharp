using System;
using System.IO;
using TileDB.CSharp;
namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TileDB Core Version: {0}", CoreUtil.GetCoreLibVersion());
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "/source/drago-testing-serviceaccount.json");
            
            /*
            using (var readtext = new StreamReader(@"/source/drago-testing-serviceaccount.json"))
            {
                while (!readtext.EndOfStream)
                {
                    string currentLine = readtext.ReadLine();
                    Console.WriteLine(currentLine);
                }
            }
            */
            ExampleQuery.Run();
            //ExampleIncompleteQuery.Run();
            //ExampleIncompleteQueryStringDimensions.Run();

            //ExampleFile.RunLocal();
            // ExampleFile.RunCloud("tiledb_api_token", "tiledb_namespace", "cloud_array_name", "s3://bucket/prefix/");

            //ExampleGroup.RunLocal();
            // ExampleGroup.RunCloud("tiledb_api_token", "tiledb_namespace", "s3://bucket/prefix");
        }
    }
}