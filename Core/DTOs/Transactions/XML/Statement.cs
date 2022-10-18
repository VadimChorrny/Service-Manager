using System.Xml.Serialization;

namespace Core.DTOs.Transactions.XML
{
    [Serializable]
    public class Statement
    {
        [XmlAttribute("description")]
        public string Description { get; set; }
    }
}