using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace JotaSystem.Sdk.Core.CrossCutting.Providers.Enum
{
    public enum MapProviderEnum
    {
        [Display(Name = "Google Maps")]
        [EnumMember(Value = "google_maps")]
        GoogleMaps = 0,

        [Display(Name = "MapBox")]
        [EnumMember(Value = "mapbox")]
        MapBox = 1,

        [Display(Name = "Here Maps")]
        [EnumMember(Value = "here_maps")]
        HereMaps = 2,

        [Display(Name = "OpenStreetMap")]
        [EnumMember(Value = "openstreetmap")]
        OpenStreetMap = 3
    }
}