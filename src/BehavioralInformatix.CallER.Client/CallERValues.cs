using System;
using Newtonsoft.Json;

namespace BehavioralInformatix.CallER.Client
{

    [Serializable]
    public class CallERValues<TValue>
    {

        /// <summary>
        /// Value for the agent.
        /// </summary>
        [JsonProperty("agent")]
        public TValue Agent { get; set; }

        /// <summary>
        /// Value for the customer.
        /// </summary>
        [JsonProperty("customer")]
        public TValue Customer { get; set; }

    }

}
