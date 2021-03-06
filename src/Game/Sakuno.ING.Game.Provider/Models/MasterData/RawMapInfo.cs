﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Sakuno.ING.Game.Json.Converters;

namespace Sakuno.ING.Game.Models.MasterData
{
    [Identifier]
    public readonly struct MapId : IEquatable<MapId>, IComparable<MapId>
    {
        private readonly int value;
        public MapId(int value) => this.value = value;

        public MapAreaId AreaId => (MapAreaId)(value / 10);
        public int CategoryNo => value % 10;

        public int CompareTo(MapId other) => value - other.value;
        public bool Equals(MapId other) => value == other.value;

        public static implicit operator int(MapId id) => id.value;
        public static explicit operator MapId(int value) => new MapId(value);

        public static bool operator ==(MapId left, MapId right) => left.value == right.value;
        public static bool operator !=(MapId left, MapId right) => left.value != right.value;
        public override bool Equals(object obj) => (MapId)obj == this;
        public override int GetHashCode() => value;
        public override string ToString() => $"{value / 10}-{value % 10}";
    }

    public sealed class RawMapInfo : IIdentifiable<MapId>
    {
        internal RawMapInfo() { }

        [JsonProperty("api_id")]
        public MapId Id { get; internal set; }
        [JsonProperty("api_maparea_id")]
        public MapAreaId MapAreaId { get; internal set; }
        [JsonProperty("api_no")]
        public int CategoryNo { get; internal set; }

        [JsonProperty("api_name")]
        public string Name { get; internal set; }
        [JsonProperty("api_level")]
        public int StarDifficulty { get; internal set; }
        [JsonProperty("api_opetext")]
        public string OperationName { get; internal set; }
        [JsonProperty("api_infotext"), JsonConverter(typeof(HtmlNewLineEater))]
        public string Description { get; internal set; }

        [JsonProperty("api_item")]
        public IReadOnlyCollection<UseItemId> ItemAcquirements { get; internal set; }
        [JsonProperty("api_required_defeat_count")]
        public int? RequiredDefeatCount { get; internal set; }

        internal int[] api_sally_flag;
        public bool CanUseNormalFleet => api_sally_flag.At(0) != 0;
        public bool CanUseStrikingForceFleet => api_sally_flag.At(2) != 0;
        public bool CanUseCombinedFleet(CombinedFleetType type)
            => (api_sally_flag.At(1) & (1 << ((int)type - 1))) != 0;

        public RawMapBgmInfo BgmInfo { get; internal set; }
    }
}
