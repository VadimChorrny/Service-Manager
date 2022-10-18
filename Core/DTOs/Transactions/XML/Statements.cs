using System.Xml.Serialization;

namespace Core.DTOs.Transactions.XML
{
    [Serializable]
    public class Statements
    {
        [XmlArray("statement")]
        public Statement[] StatementsArr { get; set; }
    }
}