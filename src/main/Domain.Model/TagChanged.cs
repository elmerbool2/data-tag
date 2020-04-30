using CQRSlite.Events;
using Newtonsoft.Json;
using System;

namespace ei8.Data.Tag.Domain.Model
{
    public class TagChanged : IEvent
    {
        public readonly string Tag;

        public TagChanged(Guid id, string tag)
        {
            this.Id = id;
            this.Tag = tag;
        }

        public Guid Id { get; set; }

        public int Version { get; set; }

        [JsonProperty(PropertyName = "Timestamp")]
        public DateTimeOffset TimeStamp { get; set; }
    }
}
