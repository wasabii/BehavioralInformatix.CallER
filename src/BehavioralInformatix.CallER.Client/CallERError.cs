using System;

using Newtonsoft.Json;

namespace BehavioralInformatix.CallER.Client
{

    [Serializable]
    public class CallERError
    {

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("type")]
        public CallERErrorType Type { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

    }

}
