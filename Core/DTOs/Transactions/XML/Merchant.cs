using System.Xml.Serialization;

namespace Core.DTOs.Transactions.XML
{
    [Serializable]
    public class Merchant
    {
        [XmlElement(ElementName = "id")]
        public string Id { get; set; }
        [XmlElement(ElementName = "signature")]
        public string Signature { get; set; }
    }
}