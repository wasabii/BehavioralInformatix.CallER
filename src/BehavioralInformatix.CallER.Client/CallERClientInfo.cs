using System;

using Newtonsoft.Json;

namespace BehavioralInformatix.CallER.Client
{

    [Serializable]
    public class CallERClientInfo
    {

        [JsonProperty("cid")]
        public long ClientId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("tag")]
        public string[] Tag { get; set; }

        [JsonProperty("storedata")]
        public CallERStoreDataFlag StoreData { get; set; }

    }

}
