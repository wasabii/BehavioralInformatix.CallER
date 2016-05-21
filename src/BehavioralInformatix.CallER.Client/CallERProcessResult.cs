using System;

using Newtonsoft.Json;

namespace BehavioralInformatix.CallER.Client
{

    [Serializable]
    public class CallERProcessResult
    {

        [JsonProperty("basic")]
        public CallERBasicMetrics Basic { get; set; }

        [JsonProperty("core")]
        public CallERCoreMetrics Core { get; set; }

        [JsonProperty("kpi")]
        public CallERKPIMetrics KPI { get; set; }

    }

}
