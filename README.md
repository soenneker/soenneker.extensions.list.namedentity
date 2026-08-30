[![](https://img.shields.io/nuget/v/soenneker.extensions.list.namedentity.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.list.namedentity/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.list.namedentity/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.list.namedentity/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.extensions.list.namedentity.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.list.namedentity/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.list.namedentity/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.list.namedentity/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.List.NamedEntity
Projects named entities into lightweight `IdNamePair` DTOs, with optional first-ID deduplication.

## Installation

```bash
dotnet add package Soenneker.Extensions.List.NamedEntity
```

## Copy every entity

```csharp
using Soenneker.Extensions.List.NamedEntity;

List<IdNamePair> pairs = entities.ToIdNamePairs();
```

`ToIdNamePairs()` returns one new DTO for every source item, in the same order:

```csharp
var entities = new List<INamedEntity>
{
    first,
    second
};

List<IdNamePair> pairs = entities.ToIdNamePairs();
```

Only `Id` and `Name` are copied. The result list and its DTO objects are independent of the source entities; later changes are not synchronized in either direction. Source duplicates are preserved.

## Keep the first entity for each ID

```csharp
List<IdNamePair> unique = entities.ToUniqueIdNamePairs();
```

`ToUniqueIdNamePairs()` compares IDs with ordinal, case-sensitive equality. It keeps the first entity for each ID, including that entity's name, and preserves the order in which unique IDs first appear. For example, IDs `"ABC"` and `"abc"` are distinct.

Both methods require a non-null `List<INamedEntity>` whose elements are non-null. An empty source returns a new empty list. They materialize immediately and do not modify the source.
