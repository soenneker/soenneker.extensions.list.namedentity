using System.Collections.Generic;
using Soenneker.Entities.Named.Abstract;

namespace Soenneker.Extensions.List.NamedEntity;

/// <summary>
/// A collection of helpful List{NamedEntity} extension methods
/// </summary>
public static class ListNamedEntityExtension
{
    /// <summary>
    /// Converts a list of INamedEntity objects to a list of IdNamePair objects.
    /// </summary>
    /// <param name="values">The list of INamedEntity objects to convert.</param>
    /// <returns>A list of IdNamePair objects with the Id and Name properties from the INamedEntity objects.</returns>
    public static List<Dtos.IdNamePair.IdNamePair> ToIdNamePairs(this IList<INamedEntity> values)
    {
        List<Dtos.IdNamePair.IdNamePair> result = new List<Dtos.IdNamePair.IdNamePair>(values.Count);

        for (var i = 0; i < values.Count; i++)
        {
            INamedEntity namedEntity = values[i];

            result.Add(new Dtos.IdNamePair.IdNamePair
            {
                Id = namedEntity.Id,
                Name = namedEntity.Name
            });
        }

        return result;
    }

    /// <summary>
    /// Converts a list of INamedEntity objects to a list of unique IdNamePair objects. <para/>
    /// Only unique Ids are included in the resulting list.
    /// </summary>
    /// <param name="values">The list of INamedEntity objects to convert.</param>
    /// <returns>A list of unique IdNamePair objects with the Id and Name properties from the INamedEntity objects.</returns>
    public static List<Dtos.IdNamePair.IdNamePair> ToUniqueIdNamePairs(this IList<INamedEntity> values)
    {
        var uniqueIds = new HashSet<string>();
        var idNamePairs = new List<Dtos.IdNamePair.IdNamePair>(values.Count);

        for (var i = 0; i < values.Count; i++)
        {
            INamedEntity pair = values[i];

            if (uniqueIds.Add(pair.Id)) // Add returns false if the item is already in the set
            {
                idNamePairs.Add(new Dtos.IdNamePair.IdNamePair
                {
                    Id = pair.Id,
                    Name = pair.Name
                });
            }
        }

        return idNamePairs;
    }
}