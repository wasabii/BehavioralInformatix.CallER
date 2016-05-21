using System;

using Newtonsoft.Json;

namespace BehavioralInformatix.CallER.Client
{

    public class CallERJob
    {

        /// <summary>
        /// Optionally, a name for the job request.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// The customer's ID.
        /// </summary>
        [JsonProperty("customerId", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomerId { get; set; }

        /// <summary>
        /// The customer's industry index.
        /// </summary>
        [JsonProperty("customerInd", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomerIndustryIndex { get; set; }

        /// <summary>
        /// The agent's ID.
        /// </summary>
        [JsonProperty("agentId", NullValueHandling = NullValueHandling.Ignore)]
        public string AgentId { get; set; }

        /// <summary>
        /// The agents team ID.
        /// </summary>
        [JsonProperty("agentTeam", NullValueHandling = NullValueHandling.Ignore)]
        public string AgentTeam { get; set; }

        /// <summary>
        /// Campaign's ID.
        /// </summary>
        [JsonProperty("campaignId", NullValueHandling = NullValueHandling.Ignore)]
        public string CampaignId { get; set; }

        /// <summary>
        /// The type of call.
        /// </summary>
        [JsonProperty("calltype", NullValueHandling = NullValueHandling.Ignore)]
        public CallERCallType? CallType { get; set; }

        /// <summary>
        /// Time of call.
        /// </summary>
        [JsonProperty("calltime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CallTime { get; set; }

        /// <summary>
        /// Timezone of time of call.
        /// </summary>
        [JsonProperty("timezone", NullValueHandling = NullValueHandling.Ignore)]
        public int? TimeZone { get; set; }

        /// <summary>
        /// Who initiated the call.
        /// </summary>
        [JsonProperty("calldirection", NullValueHandling = NullValueHandling.Ignore)]
        public CallERCallDirection CallDirection { get; set; }

        /// <summary>
        /// ANI information.
        /// </summary>
        [JsonProperty("ANI", NullValueHandling = NullValueHandling.Ignore)]
        public string ANI { get; set; }

        /// <summary>
        /// Number of channels in audio data.
        /// </summary>
        [JsonProperty("channels", NullValueHandling = NullValueHandling.Ignore)]
        public short Channels { get; set; }

        /// <summary>
        /// Request to store incoming process data on a per job basis.
        /// </summary>
        [JsonProperty("storedata", NullValueHandling = NullValueHandling.Ignore)]
        public CallERStoreDataFlag? StoreData { get; set; }

        /// <summary>
        /// Client defined tagging of processing job.
        /// </summary>
        [JsonProperty("tag", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Tag { get; set; }

    }

}
