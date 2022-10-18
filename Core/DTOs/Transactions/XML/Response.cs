using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.DTOs.Transactions.XML
{
    [Serializable]
    [XmlRoot(ElementName = "Response")]
    public class Response
    {
        [XmlElement(ElementName = "merchant")]
        public Merchant Merchant { get; set; }
        [XmlElement(ElementName = "data")]
        public Data Data { get; set; }
    }
}
