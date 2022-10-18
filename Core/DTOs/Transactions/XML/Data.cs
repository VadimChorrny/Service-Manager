using System.Xml.Serialization;

namespace Core.DTOs.Transactions.XML
{
    [Serializable]
    public class Data
    {
        [XmlElement(ElementName = "oper")]
        public string Oper { get; set; }
        [XmlElement(ElementName = "info")]
        public Info Info { get; set; }
    }
}