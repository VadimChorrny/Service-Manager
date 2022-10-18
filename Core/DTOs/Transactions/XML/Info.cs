using System.Xml.Serialization;

namespace Core.DTOs.Transactions.XML
{
    [Serializable]
    public class Info
    {
        [XmlElement(ElementName = "statements")]
        public Statements Statements { get; set; }
    }
}