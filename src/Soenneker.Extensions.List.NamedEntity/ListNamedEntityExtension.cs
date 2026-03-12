using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using Soenneker.Entities.Named.Abstract;

namespace Soenneker.Extensions.List.NamedEntity;

/// <summary>
/// A collection of helpful <see cref="List{T}"/> extension methods for working with <see cref="INamedEntity"/> lists.
/// </summary>
public static class ListNamedEntityExtension
{
    /// <summary>
    /// Converts a list of <see cref="INamedEntity"/> objects to a list of <c>IdNamePair</c> objects.
    /// </summary>
    /// <param name="values">The list of <see cref="INamedEntity"/> objects to convert.</param>
    /// <returns>
    /// A list of <c>IdNamePair</c> objects with the <c>Id</c> and <c>Name</c> copied from each entity.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="values"/> is <see langword="null"/>.</exception>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static List<Dtos.IdNamePair.IdNamePair> ToIdNamePairs(this List<INamedEntity> values)
    {
        if (values is null)
            throw new ArgumentNullException(nameof(values));

        int count = values.Count;
        var result = new List<Dtos.IdNamePair.IdNamePair>(count);

        for (int i = 0; i < count; i++)
        {
            var e = values[i];

            result.Add(new Dtos.IdNamePair.IdNamePair
            {
                Id = e.Id,
                Name = e.Name
            });
        }

        return result;
    }

    /// <summary>
    /// Converts a list of <see cref="INamedEntity"/> objects to a list of unique <c>IdNamePair</c> objects.
    /// Only the first occurrence of each <c>Id</c> is included.
    /// </summary>
    /// <param name="values">The list of <see cref="INamedEntity"/> objects to convert.</param>
    /// <returns>
    /// A list of unique <c>IdNamePair</c> objects based on distinct <c>Id</c> values.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="values"/> is <see langword="null"/>.</exception>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static List<Dtos.IdNamePair.IdNamePair> ToUniqueIdNamePairs(this List<INamedEntity> values)
    {
        if (values is null)
            throw new ArgumentNullException(nameof(values));

        int count = values.Count;

        // Ordinal comparison is correct + fastest for identifiers
        var seenIds = new HashSet<string>(capacity: count, comparer: StringComparer.Ordinal);
        var result = new List<Dtos.IdNamePair.IdNamePair>(count);

        for (int i = 0; i < count; i++)
        {
            var e = values[i];
            string id = e.Id;

            if (seenIds.Add(id))
            {
                result.Add(new Dtos.IdNamePair.IdNamePair
                {
                    Id = id,
                    Name = e.Name
                });
            }
        }

        return result;
    }
}
