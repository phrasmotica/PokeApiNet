using System.Collections.Generic;
using System.Linq;

namespace PokeApiNet.Models
{
    /// <summary>
    /// The base class for classes that have an API endpoint. These
    /// classes can also be cached with their id value.
    /// </summary>
    public abstract class ResourceBase
    {
        /// <summary>
        /// The identifier for this resource
        /// </summary>
        public abstract int Id { get; set; }

        /// <summary>
        /// The endpoint string for this resource
        /// </summary>
        public static string ApiEndpoint { get; }
    }

    /// <summary>
    /// The base class for API resources that have a name property
    /// </summary>
    public abstract class NamedApiResource : ResourceBase
    {
        /// <summary>
        /// The name of this resource
        /// </summary>
        public abstract string Name { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// Returns the name of this API resource in the given locale.
        /// </summary>
        public virtual string GetName(string locale)
        {
            return Names?.FirstOrDefault(n => n.Language.Name == locale)?.Name;
        }

        /// <summary>
        /// Returns the English name of this API resource.
        /// </summary>
        public string GetEnglishName()
        {
            return GetName("en");
        }
    }

    /// <summary>
    /// The base class for API resources that don't have a name property
    /// </summary>
    public abstract class ApiResource : ResourceBase { }
}
