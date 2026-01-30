using Newtonsoft.Json;

namespace RealTime
{
    public class RealtimeConfig
    {
        [JsonProperty("time_offset")]
        public double TimeOffset { get; set; } = 4.50;

        [JsonProperty("day_night_transition")]
        public double DayNightTransition { get; set; } = 15.00;

        [JsonProperty("update_interval_ms")]
        public int UpdateIntervalMs { get; set; } = 1000;

        [JsonProperty("enabled_on_startup")]
        public bool EnabledOnStartup { get; set; } = true;
    }
}
