using System.Xml.Serialization;
using System.Xml;
using System.Collections.Generic;
using System;
using System.ComponentModel;
using System.Linq;

namespace thesis_wallet {
    [XmlRootAttribute("ContractForms")]
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
        [XmlAttribute("FuncBind")]
        public string FuncBind { get; set; } = "";
        [XmlAttribute("StateMachine")]
        public string StateMachine { get; set; } = "";
        [XmlAttribute("Role")]
        public string Role { get; set; } = "";
        [XmlAttribute("RoleMachine")]
        public string RoleMachine { get; set; } = "";

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

    public abstract class Field {
        [XmlAttribute("ParamBind")]
        public string ParamBind { get; set; } = "";
        [XmlAttribute("ViewBind")]
        public string ViewBind { get; set; } = "";
        [XmlAttribute("Label")]
        public string Label { get; set; }
        [XmlAttribute("Description")]
        public string Description { get; set; } = "";
        [XmlAttribute("ReadOnly")]
        public bool ReadOnly { get; set; } = false;

        public abstract void SetData(string data);
        public abstract void SetDataList(List<string> data);
        public abstract object GetData();
    }

    public class DateField : Field {
        [XmlIgnoreAttribute]
        public DateTime Data { get; set; }

        public override void SetData(string data) {
            Data = DateTime.Parse(data);
        }

        public override void SetDataList(List<string> data) {
            if (data.Count > 0) {
                Data = DateTime.Parse(data[0]);
            }
        }

        public override object GetData() {
            return Data;
        }
    }

    public class AddressField : Field {
        [XmlIgnoreAttribute]
        public string Data { get; set; }

        public override void SetData(string data) {
            Data = data;
        }

        public override void SetDataList(List<string> data) {
            Data = string.Join(',', data);
        }

        public override object GetData() {
            return Data;
        }
    }

    public class SingleLineField : Field {
        [XmlIgnoreAttribute]
        public string Data { get; set; }

        public override void SetData(string data) {
            Data = data;
        }

        public override void SetDataList(List<string> data) {
            Data = string.Join(',', data);
        }

        public override object GetData() {
            return Data;
        }
    }

    public class MultiLineField : Field {
        [XmlIgnoreAttribute]
        public string Data { get; set; } = Environment.NewLine;

        public override void SetData(string data) {
            Data = data;
        }

        public override void SetDataList(List<string> data) {
            Data = string.Join(Environment.NewLine, data);
        }

        public override object GetData() {
            return Data;
        }
    }

    public class IntField : Field {
        [XmlIgnoreAttribute]
        public long Data { get; set; }

        public override void SetData(string data) {
            Data = Convert.ToInt64(data);
        }

        public override void SetDataList(List<string> data) {
            if (data.Count > 0) {
                Data = Convert.ToInt64(data[0]);
            }
        }

        public override object GetData() {
            return Data;
        }
    }

    public class DecimalField : Field {
        [XmlIgnoreAttribute]
        public decimal Data { get; set; }

        public override void SetData(string data) {
            Data = Convert.ToDecimal(data);
        }

        public override void SetDataList(List<string> data) {
            if (data.Count > 0) {
                Data = Convert.ToDecimal(data[0]);
            }
        }

        public override object GetData() {
            return Data;
        }
    }

    public class BoolField : Field {
        [XmlIgnoreAttribute]
        public bool Data { get; set; }

        public override void SetData(string data) {
            Data = Convert.ToBoolean(data);
        }

        public override void SetDataList(List<string> data) {
            if (data.Count > 0) {
                Data = Convert.ToBoolean(data[0]);
            }
        }

        public override object GetData() {
            return Data;
        }
    }

    public class EnumField : Field {
        [XmlAttribute("Vertical")]
        public bool Vertical { get; set; } = false;

        [XmlIgnoreAttribute]
        public int Data { get; set; } = -1;
        [XmlElement("Option")]
        public List<string> Options { get; set; } = new List<string>();
        [XmlAttribute("Indexed")]
        public bool Indexed { get; set; } = false;

        public override void SetData(string data) {
            for (int i = 0; i < Options.Count; ++i) {
                if (Options[i] == data) {
                    Data = i;
                    return;
                }
            }
        }

        public override void SetDataList(List<string> data) {
            Options = data;
            if (Data == 0 && Options.Count > 1) {
                Data = 1;
            }
            Data = 0;
        }

        public override object GetData() {
            if (Indexed) {
                return Data;
            } else {
                return Options[Data];
            }
        }
    }

    public class DropdownField : Field {
        [XmlIgnoreAttribute]
        public int? Data { get; set; } = null;
        [XmlElement("Option")]
        public List<string> Options { get; set; } = new List<string>();
        [XmlAttribute("Indexed")]
        public bool Indexed { get; set; } = false;

        public override void SetData(string data) {
            for (int i = 0; i < Options.Count; ++i) {
                if (Options[i] == data) {
                    Data = i;
                    return;
                }
            }
        }

        public override void SetDataList(List<string> data) {
            Options = data;
            Data = null;
        }

        public override object GetData() {
            if (Indexed || Data == null) {
                return Data;
            } else {
                return Options[(int)Data];
            }
        }
    }
}
