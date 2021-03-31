//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 4.0.2
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

namespace tiledb {

public class FilterList : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  private bool swigCMemOwnBase;

  internal FilterList(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwnBase = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(FilterList obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~FilterList() {
    Dispose(false);
  }

  public void Dispose() {
    Dispose(true);
    global::System.GC.SuppressFinalize(this);
  }

  protected virtual void Dispose(bool disposing) {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwnBase) {
          swigCMemOwnBase = false;
          tiledbPINVOKE.delete_FilterList(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public FilterList(Context ctx) : this(tiledbPINVOKE.new_FilterList__SWIG_0(Context.getCPtr(ctx)), true) {
    if (tiledbPINVOKE.SWIGPendingException.Pending) throw tiledbPINVOKE.SWIGPendingException.Retrieve();
  }

  public FilterList() : this(tiledbPINVOKE.new_FilterList__SWIG_1(), true) {
  }

  public FilterList(FilterList arg0) : this(tiledbPINVOKE.new_FilterList__SWIG_2(FilterList.getCPtr(arg0)), true) {
    if (tiledbPINVOKE.SWIGPendingException.Pending) throw tiledbPINVOKE.SWIGPendingException.Retrieve();
  }

  public SWIGTYPE_p_std__shared_ptrT_tiledb_filter_list_t_t ptr() {
    SWIGTYPE_p_std__shared_ptrT_tiledb_filter_list_t_t ret = new SWIGTYPE_p_std__shared_ptrT_tiledb_filter_list_t_t(tiledbPINVOKE.FilterList_ptr(swigCPtr), true);
    if (tiledbPINVOKE.SWIGPendingException.Pending) throw tiledbPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public FilterList add_filter(Filter filter) {
    FilterList ret = new FilterList(tiledbPINVOKE.FilterList_add_filter(swigCPtr, Filter.getCPtr(filter)), true);
    if (tiledbPINVOKE.SWIGPendingException.Pending) throw tiledbPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public Filter filter(uint filter_index) {
    Filter ret = new Filter(tiledbPINVOKE.FilterList_filter(swigCPtr, filter_index), true);
    if (tiledbPINVOKE.SWIGPendingException.Pending) throw tiledbPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public uint max_chunk_size() {
    uint ret = tiledbPINVOKE.FilterList_max_chunk_size(swigCPtr);
    if (tiledbPINVOKE.SWIGPendingException.Pending) throw tiledbPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public uint nfilters() {
    uint ret = tiledbPINVOKE.FilterList_nfilters(swigCPtr);
    if (tiledbPINVOKE.SWIGPendingException.Pending) throw tiledbPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public FilterList set_max_chunk_size(uint max_chunk_size) {
    FilterList ret = new FilterList(tiledbPINVOKE.FilterList_set_max_chunk_size(swigCPtr, max_chunk_size), true);
    if (tiledbPINVOKE.SWIGPendingException.Pending) throw tiledbPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

}

}
