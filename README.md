# C# 2.0 Extra Features

This solution contains **secondary features of C# 2.0** not covered in the main set.

## Projects
- **P36_DefaultT** — Demonstrates `default(T)` in generics.
- **P37_ExternAlias** — Shows syntax for `extern alias` (requires multiple assemblies with same namespace).
- **P38_GlobalAliasQualifier** — Demonstrates `global::` to disambiguate names.
- **P39_FriendAssemblies_Lib/App** — Two-project demo of `[InternalsVisibleTo]` for friend assemblies.
- **P40_FixedSizeBuffers** — Unsafe code with fixed-size buffers in structs.
- **P41_PragmaWarning** — Using `#pragma warning disable/restore`.

## Build
```bash
dotnet restore
dotnet build
dotnet run --project P36_DefaultT
```
*Note*: P37 is only illustrative unless you add references with aliases.
