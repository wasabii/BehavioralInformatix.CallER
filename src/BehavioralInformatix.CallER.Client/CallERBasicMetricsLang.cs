using System;

using Newtonsoft.Json;

namespace BehavioralInformatix.CallER.Client
{

    [Serializable]
    public class CallERBasicMetricsLang
    {

        /// <summary>
        /// Language usage information for English.
        /// </summary>
        [JsonProperty("english")]
        public CallERValues<double> English { get; set; }

        /// <summary>
        /// Language usage information for Spanish.
        /// </summary>
        [JsonProperty("spanish")]
        public CallERValues<double> Spanish { get; set; }

    }

}
