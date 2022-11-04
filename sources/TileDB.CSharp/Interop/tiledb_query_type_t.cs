namespace TileDB.Interop
{
    public enum tiledb_query_type_t
    {
        TILEDB_READ = 0,
        TILEDB_WRITE = 1,
        TILEDB_DELETE = 2,
        TILEDB_UPDATE = 3,
        TILEDB_MODIFY_EXCLUSIVE = 4,
    }
}
