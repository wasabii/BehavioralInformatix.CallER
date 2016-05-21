using System;
using BehavioralInformatix.CallER.Client.Util;
using Newtonsoft.Json;

namespace BehavioralInformatix.CallER.Client
{

    [Serializable]
    public class CallERCoreMetricsDiarization
    {

        /// <summary>
        /// Range start time.
        /// </summary>
        [JsonProperty("st")]
        [JsonConverter(typeof(TimeSpanAsSecondsJsonConverter))]
        public TimeSpan StartTime { get; set; }

        /// <summary>
        /// Range end time.
        /// </summary>
        [JsonProperty("et")]
        [JsonConverter(typeof(TimeSpanAsSecondsJsonConverter))]
        public TimeSpan EndTime { get; set; }

    }

}
