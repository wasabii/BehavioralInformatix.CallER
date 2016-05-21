using System;
using BehavioralInformatix.CallER.Client.Util;
using Newtonsoft.Json;

namespace BehavioralInformatix.CallER.Client
{

    [Serializable]
    public class CallERBasicMetricsVAD
    {

        /// <summary>
        /// Agent talk time.
        /// </summary>
        [JsonProperty("agent")]
        [JsonConverter(typeof(TimeSpanAsSecondsJsonConverter))]
        public TimeSpan Agent { get; set; }

        /// <summary>
        /// Customer talk time.
        /// </summary>
        [JsonProperty("customer")]
        [JsonConverter(typeof(TimeSpanAsSecondsJsonConverter))]
        public TimeSpan Customer { get; set; }

        /// <summary>
        /// Overlap talk.
        /// </summary>
        [JsonProperty("overlap")]
        [JsonConverter(typeof(TimeSpanAsSecondsJsonConverter))]
        public TimeSpan Overlap { get; set; }

        /// <summary>
        /// Silence.
        /// </summary>
        [JsonProperty("silence")]
        [JsonConverter(typeof(TimeSpanAsSecondsJsonConverter))]
        public TimeSpan Silence { get; set; }

    }

}
