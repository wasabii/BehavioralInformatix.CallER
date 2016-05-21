using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BehavioralInformatix.CallER.Client
{

    [JsonConverter(typeof(StringEnumConverter))]
    public enum CallERCallType : 
        short
    {

        LA,
        AM,

    }

}
