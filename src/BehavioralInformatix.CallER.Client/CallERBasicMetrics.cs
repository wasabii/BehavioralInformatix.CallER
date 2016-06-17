using System;

using BehavioralInformatix.CallER.Client.Util;

using Newtonsoft.Json;

namespace BehavioralInformatix.CallER.Client
{

    [Serializable]
    public class CallERBasicMetrics
    {

        /// <summary>
        /// Duration of call in seconds.
        /// </summary>
        [JsonProperty("totalduration")]
        [JsonConverter(typeof(TimeSpanAsSecondsJsonConverter))]
        public TimeSpan TotalDuration { get; set; }

        /// <summary>
        /// Number of speaker changes (turns).
        /// </summary>
        [JsonProperty("speakerchanges")]
        public int SpeakerChanges { get; set; }

        /// <summary>
        /// Number of beeps found in call.
        /// </summary>
        [JsonProperty("numbeepfound")]
        public int NumberOfBeepsFound { get; set; }

        /// <summary>
        /// Number of rings found in call.
        /// </summary>
        [JsonProperty("numringfound")]
        public int NumberOfRingsFound { get; set; }

        /// <summary>
        /// Voice activity detection (VAD) results.
        /// </summary>
        [JsonProperty("vad")]
        public CallERBasicMetricsVAD VAD { get; set; }

        /// <summary>
        /// Gender information.
        /// </summary>
        [JsonProperty("gender")]
        public CallERValues<CallERGender> Gender { get; set; }

        /// <summary>
        /// Age information.
        /// </summary>
        [JsonProperty("age")]
        public CallERValues<CallERAge> Age { get; set; }

        /// <summary>
        /// Language usage information.
        /// </summary>
        [JsonProperty("lang")]
        public CallERBasicMetricsLang Lang { get; set; }

        /// <summary>
        /// Number of utterances for each party.
        /// </summary>
        [JsonProperty("utterances")]
        public CallERValues<int> Utterances { get; set; }

    }

}
