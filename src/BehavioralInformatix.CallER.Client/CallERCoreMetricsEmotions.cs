using System;

using Newtonsoft.Json;

namespace BehavioralInformatix.CallER.Client
{

    [Serializable]
    public class CallERCoreMetricsEmotions
    {

        /// <summary>
        /// Happiness.
        /// </summary>
        [JsonProperty("happy", NullValueHandling = NullValueHandling.Ignore)]
        public CallERValues<double> Happy { get; set; }

        /// <summary>
        /// Anger.
        /// </summary>
        [JsonProperty("anger", NullValueHandling = NullValueHandling.Ignore)]
        public CallERValues<double> Anger { get; set; }

        /// <summary>
        /// Frustration.
        /// </summary>
        [JsonProperty("frustration", NullValueHandling = NullValueHandling.Ignore)]
        public CallERValues<double> Frustration { get; set; }

        /// <summary>
        /// Sadness.
        /// </summary>
        [JsonProperty("sad", NullValueHandling = NullValueHandling.Ignore)]
        public CallERValues<double> Sad { get; set; }

    }

}
