using System;

using Newtonsoft.Json;

using BehavioralInformatix.CallER.Client.Util;

namespace BehavioralInformatix.CallER.Client
{

    /// <summary>
    /// Process status and other information.
    /// </summary>
    [Serializable]
    public class CallERProcessInfo
    {

        /// <summary>
        /// Unique ID for the processing job.
        /// </summary>
        [JsonProperty("pid")]
        public long ProcessId { get; set; }

        /// <summary>
        /// Unique ID of the client.
        /// </summary>
        [JsonProperty("cid")]
        public long ClientId { get; set; }

        /// <summary>
        /// Label of the processing job (Client defined).
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// Shows the processing state of the job.
        /// </summary>
        [JsonProperty("status")]
        public CallERProcessStatus Status { get; set; }

        /// <summary>
        /// Reason for success or failure.
        /// </summary>
        [JsonProperty("statusmsg")]
        public string StatusMessage { get; set; }

        /// <summary>
        /// Duration of the audio signal.
        /// </summary>
        [JsonProperty("duration", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(TimeSpanAsSecondsJsonConverter))]
        public TimeSpan? Duration { get; set; }

        /// <summary>
        /// Date and time the request for processing was inserted into CallER.
        /// </summary>
        [JsonProperty("datetime")]
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Where to find stored audio data in client's datastore in CallER cloud.
        /// </summary>
        [JsonProperty("uri", NullValueHandling = NullValueHandling.Ignore)]
        public string Uri { get; set; }

        /// <summary>
        /// For internal system use.
        /// </summary>
        [JsonProperty("internal", NullValueHandling = NullValueHandling.Ignore)]
        public string Internal { get; set; }

        /// <summary>
        /// The Customer's ID.
        /// </summary>
        [JsonProperty("customerId", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomerId { get; set; }

        /// <summary>
        /// The Customer's Industry index.
        /// </summary>
        [JsonProperty("customerInd", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomerIndustryIndex { get; set; }

        /// <summary>
        /// Agent's ID.
        /// </summary>
        [JsonProperty("agentId", NullValueHandling = NullValueHandling.Ignore)]
        public string AgentId { get; set; }

        /// <summary>
        /// Agent’s team ID.
        /// </summary>
        [JsonProperty("agentTeam", NullValueHandling = NullValueHandling.Ignore)]
        public string AgentTeam { get; set; }

        /// <summary>
        /// Campaign's ID.
        /// </summary>
        [JsonProperty("campaignId", NullValueHandling = NullValueHandling.Ignore)]
        public string CampaignId { get; set; }

        /// <summary>
        /// The type of call.
        /// </summary>
        [JsonProperty("calltype", NullValueHandling = NullValueHandling.Ignore)]
        public CallERCallType? CallType { get; set; }

        /// <summary>
        /// Call time.
        /// </summary>
        [JsonProperty("calltime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CallTime { get; set; }

        /// <summary>
        /// Timezone of call.
        /// </summary>
        [JsonProperty("timezone", NullValueHandling = NullValueHandling.Ignore)]
        public int? TimeZone { get; set; }

        /// <summary>
        /// Who initiated the call.
        /// </summary>
        [JsonProperty("calldirection")]
        public CallERCallDirection CallDirection { get; set; }

        /// <summary>
        /// ANI information.
        /// </summary>
        [JsonProperty("ANI", NullValueHandling = NullValueHandling.Ignore)]
        public string ANI { get; set; }

        /// <summary>
        /// Number of channels in audio data.
        /// </summary>
        [JsonProperty("channels")]
        public short Channels { get; set; }

        /// <summary>
        /// Request to store incoming process data.
        /// </summary>
        [JsonProperty("storedata")]
        public CallERStoreDataFlag StoreData { get; set; }

        /// <summary>
        /// Client defined tagging of processing job.
        /// </summary>
        [JsonProperty("tag")]
        public string[] Tag { get; set; }

        /// <summary>
        /// For TCP job, the ports listening.
        /// </summary>
        [JsonProperty("ports")]
        public int[] Ports { get; set; }

        /// <summary>
        /// The processing job mode of operation.
        /// </summary>
        [JsonProperty("mode")]
        public CallERMode Mode { get; set; }

    }

}
