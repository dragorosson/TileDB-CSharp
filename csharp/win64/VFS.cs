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

public class VFS : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  private bool swigCMemOwnBase;

  internal VFS(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwnBase = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(VFS obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~VFS() {
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
          tiledbPINVOKE.delete_VFS(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public VFS(Context ctx) : this(tiledbPINVOKE.new_VFS__SWIG_0(Context.getCPtr(ctx)), true) {
    if (tiledbPINVOKE.SWIGPendingException.Pending) throw tiledbPINVOKE.SWIGPendingException.Retrieve();
  }

  public VFS(Context ctx, Config config) : this(tiledbPINVOKE.new_VFS__SWIG_1(Context.getCPtr(ctx), Config.getCPtr(config)), true) {
    if (tiledbPINVOKE.SWIGPendingException.Pending) throw tiledbPINVOKE.SWIGPendingException.Retrieve();
  }

  public VFS(VFS arg0) : this(tiledbPINVOKE.new_VFS__SWIG_2(VFS.getCPtr(arg0)), true) {
    if (tiledbPINVOKE.SWIGPendingException.Pending) throw tiledbPINVOKE.SWIGPendingException.Retrieve();
  }

  public void create_bucket(string uri) {
    tiledbPINVOKE.VFS_create_bucket(swigCPtr, uri);
    if (tiledbPINVOKE.SWIGPendingException.Pending) throw tiledbPINVOKE.SWIGPendingException.Retrieve();
  }

  public void remove_bucket(string uri) {
    tiledbPINVOKE.VFS_remove_bucket(swigCPtr, uri);
    if (tiledbPINVOKE.SWIGPendingException.Pending) throw tiledbPINVOKE.SWIGPendingException.Retrieve();
  }

  public bool is_bucket(string uri) {
    bool ret = tiledbPINVOKE.VFS_is_bucket(swigCPtr, uri);
    if (tiledbPINVOKE.SWIGPendingException.Pending) throw tiledbPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void empty_bucket(string bucket) {
    tiledbPINVOKE.VFS_empty_bucket(swigCPtr, bucket);
    if (tiledbPINVOKE.SWIGPendingException.Pending) throw tiledbPINVOKE.SWIGPendingException.Retrieve();
  }

  public bool is_empty_bucket(string bucket) {
    bool ret = tiledbPINVOKE.VFS_is_empty_bucket(swigCPtr, bucket);
    if (tiledbPINVOKE.SWIGPendingException.Pending) throw tiledbPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void create_dir(string uri) {
    tiledbPINVOKE.VFS_create_dir(swigCPtr, uri);
    if (tiledbPINVOKE.SWIGPendingException.Pending) throw tiledbPINVOKE.SWIGPendingException.Retrieve();
  }

  public bool is_dir(string uri) {
    bool ret = tiledbPINVOKE.VFS_is_dir(swigCPtr, uri);
    if (tiledbPINVOKE.SWIGPendingException.Pending) throw tiledbPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void remove_dir(string uri) {
    tiledbPINVOKE.VFS_remove_dir(swigCPtr, uri);
    if (tiledbPINVOKE.SWIGPendingException.Pending) throw tiledbPINVOKE.SWIGPendingException.Retrieve();
  }

  public bool is_file(string uri) {
    bool ret = tiledbPINVOKE.VFS_is_file(swigCPtr, uri);
    if (tiledbPINVOKE.SWIGPendingException.Pending) throw tiledbPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void remove_file(string uri) {
    tiledbPINVOKE.VFS_remove_file(swigCPtr, uri);
    if (tiledbPINVOKE.SWIGPendingException.Pending) throw tiledbPINVOKE.SWIGPendingException.Retrieve();
  }

  public ulong dir_size(string uri) {
    ulong ret = tiledbPINVOKE.VFS_dir_size(swigCPtr, uri);
    if (tiledbPINVOKE.SWIGPendingException.Pending) throw tiledbPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public SWIGTYPE_p_std__vectorT_std__string_t ls(string uri) {
    SWIGTYPE_p_std__vectorT_std__string_t ret = new SWIGTYPE_p_std__vectorT_std__string_t(tiledbPINVOKE.VFS_ls(swigCPtr, uri), true);
    if (tiledbPINVOKE.SWIGPendingException.Pending) throw tiledbPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public ulong file_size(string uri) {
    ulong ret = tiledbPINVOKE.VFS_file_size(swigCPtr, uri);
    if (tiledbPINVOKE.SWIGPendingException.Pending) throw tiledbPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void move_file(string old_uri, string new_uri) {
    tiledbPINVOKE.VFS_move_file(swigCPtr, old_uri, new_uri);
    if (tiledbPINVOKE.SWIGPendingException.Pending) throw tiledbPINVOKE.SWIGPendingException.Retrieve();
  }

  public void move_dir(string old_uri, string new_uri) {
    tiledbPINVOKE.VFS_move_dir(swigCPtr, old_uri, new_uri);
    if (tiledbPINVOKE.SWIGPendingException.Pending) throw tiledbPINVOKE.SWIGPendingException.Retrieve();
  }

  public void touch(string uri) {
    tiledbPINVOKE.VFS_touch(swigCPtr, uri);
    if (tiledbPINVOKE.SWIGPendingException.Pending) throw tiledbPINVOKE.SWIGPendingException.Retrieve();
  }

  public Context context() {
    global::System.IntPtr cPtr = tiledbPINVOKE.VFS_context(swigCPtr);
    Context ret = (cPtr == global::System.IntPtr.Zero) ? null : new Context(cPtr, true);
    if (tiledbPINVOKE.SWIGPendingException.Pending) throw tiledbPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public SWIGTYPE_p_std__shared_ptrT_tiledb_vfs_t_t ptr() {
    SWIGTYPE_p_std__shared_ptrT_tiledb_vfs_t_t ret = new SWIGTYPE_p_std__shared_ptrT_tiledb_vfs_t_t(tiledbPINVOKE.VFS_ptr(swigCPtr), true);
    if (tiledbPINVOKE.SWIGPendingException.Pending) throw tiledbPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public Config config() {
    Config ret = new Config(tiledbPINVOKE.VFS_config(swigCPtr), true);
    if (tiledbPINVOKE.SWIGPendingException.Pending) throw tiledbPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

}

}
