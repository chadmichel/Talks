using System.Runtime.Serialization;

namespace DPLRef.eCommerce.Common.Shared
{
    [DataContract]
    public class ResponseBase
    {
        [DataMember]
        public bool Success { get; set; }
        
        [DataMember]
        public string Message { get; set; } 
    }
}
