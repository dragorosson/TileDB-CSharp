To use TileDB-CSharp in your own application, please add the following reference information in your *.csproj files.
## Windows
```
  <ItemGroup Condition=" '$(OS)' == 'Windows_NT' ">
    <None Include="..\..\dist\Windows\lib\tiledb.dll" Link="tiledb.dll">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </None>
    <None Include="..\..\dist\Windows\lib\tiledbcs.dll" Link="tiledbcs.dll">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </None>
    <None Include="..\..\dist\Windows\lib\zlib.dll" Link="zlib.dll">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </None>
  </ItemGroup>

  <ItemGroup Condition=" '$(OS)' == 'Windows_NT' ">
    <Reference Include="TileDB.CSharp">
      <HintPath>..\..\dist\Windows\lib\net5.0\TileDB.CSharp.dll</HintPath>
    </Reference>
  </ItemGroup>
```
## Linux
```
  <ItemGroup Condition=" '$([System.Runtime.InteropServices.RuntimeInformation]::IsOSPlatform($([System.Runtime.InteropServices.OSPlatform]::Linux)))' ">
    <None Include="..\..\dist\Linux\lib\libtiledb.so.2.3" Link="libtiledb.so.2.3">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </None>
    <None Include="..\..\dist\Linux\lib\tiledbcs.so" Link="tiledbcs.so">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </None>
    <None Include="..\..\dist\Linux\lib\libz.so" Link="libz.so">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </None>
  </ItemGroup>
  <ItemGroup Condition=" '$([System.Runtime.InteropServices.RuntimeInformation]::IsOSPlatform($([System.Runtime.InteropServices.OSPlatform]::Linux)))' ">
    <Reference Include="TileDB.CSharp">
      <HintPath>..\..\dist\Linux\lib\net5.0\TileDB.CSharp.dll</HintPath>
    </Reference>
  </ItemGroup>
```

## macOS
```
  <ItemGroup Condition=" '$([System.Runtime.InteropServices.RuntimeInformation]::IsOSPlatform($([System.Runtime.InteropServices.OSPlatform]::OSX)))' ">
    <None Include="..\..\dist\Darwin\lib\libtiledb.dylib" Link="libtiledb.dylib">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </None>
    <None Include="..\..\dist\Darwin\lib\tiledbcs.dylib" Link="tiledbcs.dylib">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </None>
    <None Include="..\..\dist\Darwin\lib\libz.dylib" Link="libz.dylib">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </None>
  </ItemGroup>
  <ItemGroup Condition=" '$([System.Runtime.InteropServices.RuntimeInformation]::IsOSPlatform($([System.Runtime.InteropServices.OSPlatform]::OSX)))' ">
    <Reference Include="TileDB.CSharp">
      <HintPath>..\..\dist\Darwin\lib\net5.0\TileDB.CSharp.dll</HintPath>
    </Reference>
  </ItemGroup>  
```