using System.Collections.Generic;
using Newtonsoft.Json;

namespace Hal.Engine.Interfaces
{
    public interface IResource<TContent> : IResourceBase
    {
        [JsonProperty("links")]
        IList<Link> Links { get; set; }

        [JsonProperty("content")]
        TContent Content { get; set; }

        [JsonProperty("meta")]
        object Meta { get; set; }
    }
}