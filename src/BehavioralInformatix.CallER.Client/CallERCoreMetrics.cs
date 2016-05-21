using System;

using Newtonsoft.Json;

namespace BehavioralInformatix.CallER.Client
{

    [Serializable]
    public class CallERCoreMetrics
    {

        /// <summary>
        /// Contains the measured strength of  emotion (aka activation or arousal).
        /// </summary>
        [JsonProperty("strength")]
        public CallERValues<double> Strength { get; set; }

        /// <summary>
        /// Contains the measured positivity or  negativity of the emotion (aka  valence).
        /// </summary>
        [JsonProperty("positivity")]
        public CallERValues<double> Positivity { get; set; }

        /// <summary>
        /// Discrete emotion analysis.
        /// </summary>
        [JsonProperty("emotions")]
        public CallERCoreMetricsEmotions Emotions { get; set; }

        /// <summary>
        /// Contains engagement information.
        /// </summary>
        [JsonProperty("engagement")]
        public CallERValues<double> Engagement { get; set; }

        /// <summary>
        /// Contains politeness information.
        /// </summary>
        [JsonProperty("politeness")]
        public CallERValues<double> Politeness { get; set; }

        /// <summary>
        /// Contains empathy information.
        /// </summary>
        [JsonProperty("empathy")]
        public CallERValues<double> Empathy { get; set; }

        /// <summary>
        /// Contains sound quality information.
        /// </summary>
        [JsonProperty("soundquality")]
        public CallERValues<double> SoundQuality { get; set; }

        /// <summary>
        /// Diarization information.
        /// </summary>
        [JsonProperty("diarization")]
        public CallERValues<CallERCoreMetricsDiarization[]> Diarization { get; set; }

    }

}
