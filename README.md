# CSharp-Version2_Addons_Extra-Samples

## What’s in the repo (at a glance)

The solution **CSharpV2_Extras.sln** contains six tiny samples that show lesser-known C# 2.0 features: 
- `default(T)` 
- `extern alias` 
- `global::` alias qualifier 
- Friend assemblies via `InternalsVisibleTo` 
- Fixed-size buffers 
- `#pragma warning disable/restore`

The README also shows basic build/run commands.

---

## P36_DefaultT — `default(T)`

**What it is:** In generics, `default(T)` gives the type’s default value: `null` for reference types, zero-bit pattern for value types (`0`, `false`, `default(DateTime)` etc.).  

**Why/when:** Useful when you need a neutral “no value” for an unknown `T`, e.g., initializing fields, returning “no result,” or resetting state in generic containers.

```csharp
T current = default(T);     // null if T is a class, otherwise zeroed value
if (EqualityComparer<T>.Default.Equals(current, default(T))) { /* ... */ }
```

The repo’s **P36_DefaultT** shows this usage.  
Build hint: `dotnet run --project P36_DefaultT`.

---

## P37_ExternAlias — `extern alias`

**What it is:** Lets you reference two assemblies that define the same fully-qualified type/namespace by assigning reference aliases and qualifying with them in code.

**Why/when:** Rare, but invaluable when two libraries collide (e.g., two versions of the same package or two different vendors that used the same namespaces).

**How:**

1. Give each reference an alias (in `.csproj` or IDE reference properties).  
2. In code:

```csharp
extern alias V1; 
extern alias V2;

using TypeFromV1 = V1::Vendor.Product.Widget;
using TypeFromV2 = V2::Vendor.Product.Widget;
```

The sample notes it’s “illustrative unless you add references with aliases,” which is normal for this feature.

---

## P38_GlobalAliasQualifier — `global::`

**What it is:** `global::` refers to the root namespace, preventing name shadowing by local namespaces or types.

**Why/when:** If you (or a dependency) declared a type/namespace that accidentally hides a BCL or root-level type, qualify with `global::` to be unambiguous.

```csharp
// If 'System' was shadowed in your project:
var utc = global::System.DateTime.UtcNow;
```

The repo demonstrates this exact disambiguation pattern.

---

## P39_FriendAssemblies_Lib/App — Friend assemblies with `[InternalsVisibleTo]`

**What it is:** The `InternalsVisibleTo` assembly attribute lets another assembly see your `internal` members (a “friend” assembly).

**Why/when:** Common for unit tests or a tightly-coupled pair of assemblies that must share internals without making them `public`.

**How:**

```csharp
// In the library’s AssemblyInfo.cs or project-level Attributes file:
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("FriendAssemblyName")] // exact assembly name
```

If the library is strong-named, the friend must be referenced with its public key.  
The repo splits this into **P39_FriendAssemblies_Lib** and **P39_FriendAssemblies_App** to show the interaction.

---

## P40_FixedSizeBuffers — `unsafe` fixed-size buffers

**What it is:** In an `unsafe` context, structs can embed fixed-length arrays:

```csharp
public unsafe struct Packet
{
    public fixed byte Data[256];
}
```

**Why/when:** Interop and high-performance scenarios where you need contiguous, unmanaged-style memory (e.g., calling native APIs, binary protocols). Requires `/unsafe` and is best isolated behind safe wrappers.

The sample shows how to declare and use such buffers inside structs.

---

## P41_PragmaWarning — `#pragma warning disable/restore`

**What it is:** Compiler-local suppression of specific warnings by ID:

```csharp
#pragma warning disable CS0168   // variable declared but never used
int unused;
#pragma warning restore CS0168
```

**Why/when:** To silence a *known/intentional* warning in a tiny region without changing global rules. Prefer targeted suppression over blanket, file-wide disables.

The project demonstrates scoped `disable/restore` usage.

---

## Building & running

From the repo root:

```bash
dotnet restore
dotnet build
dotnet run --project P36_DefaultT
```

(Other projects are similar; **P37_ExternAlias** needs reference aliases to fully run.)
