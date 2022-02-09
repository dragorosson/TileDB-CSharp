﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileDB
{
    public unsafe class Filter : IDisposable
    {

        private TileDB.Interop.FilterHandle handle_;
        private Context ctx_;
        private bool disposed_ = false;


        internal Filter()
        {
            ctx_ = new Context();
            handle_ = new TileDB.Interop.FilterHandle(ctx_.Handle, TileDB.Interop.tiledb_filter_type_t.TILEDB_FILTER_NONE);
        }

        public Filter(FilterType filter_type)
        {
            ctx_ = new Context();
            handle_ = new TileDB.Interop.FilterHandle(ctx_.Handle, (TileDB.Interop.tiledb_filter_type_t)(filter_type));
        }

        public Filter(Context ctx, FilterType filter_type)
        {
            ctx_ = ctx;
            handle_ = new TileDB.Interop.FilterHandle(ctx_.Handle, (TileDB.Interop.tiledb_filter_type_t)(filter_type));
        }

        internal Filter(Context ctx, TileDB.Interop.FilterHandle handle)
        {
            ctx_ = ctx;
            handle_ = handle;
        }


        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {

            if (!disposed_)
            {
                if (disposing && (!handle_.IsInvalid))
                {
                    handle_.Dispose();
                }

                disposed_ = true;
            }

        }

        internal Interop.FilterHandle Handle
        {
            get { return handle_; }
        }

        public FilterType filter_type()
        {
            TileDB.Interop.tiledb_filter_type_t tiledb_filter_type= TileDB.Interop.tiledb_filter_type_t.TILEDB_FILTER_NONE;
            ctx_.handle_error(TileDB.Interop.Methods.tiledb_filter_get_type(ctx_.Handle, handle_, &tiledb_filter_type));
            return (FilterType)tiledb_filter_type;
        }

        protected void check_filter_option<T>(FilterOption filter_option) 
        {
            //check for filter option 
            bool is_compression_level = filter_option == FilterOption.TILEDB_COMPRESSION_LEVEL && typeof(T) == typeof(System.Int32);
            bool is_bid_width_max_window = filter_option == FilterOption.TILEDB_BIT_WIDTH_MAX_WINDOW && typeof(T) == typeof(System.UInt32);
            bool is_positive_delta_max_window = filter_option == FilterOption.TILEDB_POSITIVE_DELTA_MAX_WINDOW && typeof(T) == typeof(System.UInt32);

            if (is_compression_level || is_bid_width_max_window || is_positive_delta_max_window)
            {
                return;
            }
            throw new System.NotSupportedException("Filter, type:" + typeof(T).ToString() + " is not supported for filter option:" + filter_option.ToString());
        }

        public void set_option<T>(FilterOption filter_option, T value) where T: struct 
        {
            //check for filter option 
            check_filter_option<T>(filter_option);

            TileDB.Interop.tiledb_filter_option_t tiledb_filter_option = (TileDB.Interop.tiledb_filter_option_t)filter_option;
            T[] data = new T[1] { value };
            System.Runtime.InteropServices.GCHandle dataGCHandle = System.Runtime.InteropServices.GCHandle.Alloc(data, System.Runtime.InteropServices.GCHandleType.Pinned);
            ctx_.handle_error(TileDB.Interop.Methods.tiledb_filter_set_option(ctx_.Handle, handle_, tiledb_filter_option, (void*)dataGCHandle.AddrOfPinnedObject()));
            dataGCHandle.Free();
        }

        public T get_option<T>(FilterOption filter_option) where T: struct
        {
            //check for filter option 
            check_filter_option<T>(filter_option);
       
            T result;
            TileDB.Interop.tiledb_filter_option_t tiledb_filter_option = (TileDB.Interop.tiledb_filter_option_t)filter_option;

            T[] data = new T[1];
            System.Runtime.InteropServices.GCHandle dataGCHandle = System.Runtime.InteropServices.GCHandle.Alloc(data, System.Runtime.InteropServices.GCHandleType.Pinned);
            ctx_.handle_error(TileDB.Interop.Methods.tiledb_filter_get_option(ctx_.Handle, handle_, tiledb_filter_option, (void*)dataGCHandle.AddrOfPinnedObject()));
            result = data[0];
            dataGCHandle.Free();

            return result;
        }

    }
}