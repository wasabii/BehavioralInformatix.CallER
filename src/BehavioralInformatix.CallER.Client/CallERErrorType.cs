using System.Runtime.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BehavioralInformatix.CallER.Client
{

    [JsonConverter(typeof(StringEnumConverter))]
    public enum CallERErrorType :
        short
    {

        [EnumMember(Value = "ok")]
        Ok,

        [EnumMember(Value = "error")]
        Error,

    }

}
