using System;

using Newtonsoft.Json;

namespace BehavioralInformatix.CallER.Client
{

    [Serializable]
    public class CallERStatus
    {

        [JsonProperty("response")]
        public int Response { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }

    }

}
