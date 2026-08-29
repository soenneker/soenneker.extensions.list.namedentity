[![](https://img.shields.io/nuget/v/soenneker.extensions.list.namedentity.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.list.namedentity/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.list.namedentity/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.list.namedentity/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.extensions.list.namedentity.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.list.namedentity/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.list.namedentity/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.list.namedentity/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.List.NamedEntity
A collection of helpful List{NamedEntity} extension methods.

## Installation

```bash
dotnet add package Soenneker.Extensions.List.NamedEntity
```

## Quick start

```csharp
using Soenneker.Extensions.List.NamedEntity;

// Given an existing List<INamedEntity> named values:
var result = values.ToIdNamePairs();
```

## Common operations

- `ToIdNamePairs()` - Converts a list of `INamedEntity` objects to a list of `IdNamePair` objects. Returns a list of `IdNamePair` objects with the `Id` and `Name` copied from each entity.
- `ToUniqueIdNamePairs()` - Converts a list of `INamedEntity` objects to a list of unique `IdNamePair` objects. Only the first occurrence of each `Id` is included. Returns a list of unique `IdNamePair` objects based on distinct `Id` values.
