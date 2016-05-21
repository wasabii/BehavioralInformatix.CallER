using System;

using Newtonsoft.Json;

namespace BehavioralInformatix.CallER.Client
{

    [Serializable]
    public class CallERKPIMetrics
    {

        /// <summary>
        /// Escalation during the call, e.g., negative emotions are on the rise.
        /// </summary>
        [JsonProperty("escalation")]
        public bool Escalation { get; set; }

        /// <summary>
        /// Resolution during the call, e.g., negative emotions are falling.
        /// </summary>
        [JsonProperty("resolution")]
        public bool Resolution { get; set; }

        /// <summary>
        /// Agent’s performance score.
        /// </summary>
        [JsonProperty("agentperfscore")]
        public double AgentPerformanceScore { get; set; }

        /// <summary>
        /// Customer's satisfaction.
        /// </summary>
        [JsonProperty("satisfaction")]
        public double Satisfaction { get; set; }

        /// <summary>
        /// Propensity to buy/donate.
        /// </summary>
        [JsonProperty("propensity")]
        public double Propensity { get; set; }

        /// <summary>
        /// Call success.
        /// </summary>
        [JsonProperty("success")]
        public double Success { get; set; }

    }

}
