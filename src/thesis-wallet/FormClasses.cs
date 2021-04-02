using System.Xml.Serialization;
using System.Xml;
using System.Collections.Generic;
using System;
using System.ComponentModel;

namespace thesis_wallet {
    [XmlRootAttribute("Contract")]
    public class DContract {
        [XmlAttribute("Name")]
        public string Name { get; set; } = "";
        [XmlElement("ABI")]
        public string ABI { get; set; } = "";

        [XmlElement("Form")]
        public List<Form> Forms { get; set; } = new List<Form>();
    }

    public class Form {
        [XmlAttribute("Label")]
        public string Label { get; set; } = "";
        [XmlElement("FuncBind")]
        public string FuncBind { get; set; } = "";

        [XmlElement("FieldGroup")]
        public List<FieldGroup> FieldGroups { get; set; } = new List<FieldGroup>();
    }

    public class FieldGroup {
        [XmlAttribute("Label")]
        public string Label { get; set; } = "";
        [XmlAttribute("Vertical")]
        public bool Vertical { get; set; } = true;
        [XmlAttribute("Displayed")]
        public bool Displayed { get; set; } = true;

        [XmlElement("DateField", typeof(DateField))]
        [XmlElement("AddressField", typeof(AddressField))]
        [XmlElement("SingleLineField", typeof(SingleLineField))]
        [XmlElement("MultiLineField", typeof(MultiLineField))]
        [XmlElement("IntField", typeof(IntField))]
        [XmlElement("DecimalField", typeof(DecimalField))]
        [XmlElement("BoolField", typeof(BoolField))]
        [XmlElement("EnumField", typeof(EnumField))]
        [XmlElement("DropdownField", typeof(DropdownField))]
        public List<Field> Fields { get; set; } = new List<Field>();
    }

    public class Field {
        [XmlElement("ParamBind")]
        public string ParamBind { get; set; } = "";
        [XmlElement("ViewBind")]
        public string ViewBind { get; set; } = "";
        [XmlAttribute("Label")]
        public string Label { get; set; }
        [XmlAttribute("Description")]
        public string Description { get; set; } = "";
        [XmlAttribute("ReadOnly")]
        public bool ReadOnly { get; set; } = false;
    }

    public class DateField : Field {
        [XmlIgnoreAttribute]
        public DateTime Data { get; set; }
    }

    public class AddressField : Field {
        [XmlIgnoreAttribute]
        public string Data { get; set; }
    }

    public class SingleLineField : Field {
        [XmlIgnoreAttribute]
        public string Data { get; set; }
    }

    public class MultiLineField : Field {
        [XmlIgnoreAttribute]
        public string Data { get; set; }
    }

    public class IntField : Field {
        [XmlIgnoreAttribute]
        public long Data { get; set; }
    }

    public class DecimalField : Field {
        [XmlIgnoreAttribute]
        public decimal Data { get; set; }
    }

    public class BoolField : Field {
        [XmlIgnoreAttribute]
        public bool Data { get; set; }
    }

    public class EnumField : Field {
        [XmlAttribute("Vertical")]
        public bool Vertical { get; set; } = false;
        [XmlIgnoreAttribute]
        public List<string> Data { get; set; } = new List<string> { "A", "B", "C"};
    }

    public class DropdownField : Field {
        [XmlIgnoreAttribute]
        public List<string> Data { get; set; } = new List<string> { "A", "B", "C" };
    }
}
