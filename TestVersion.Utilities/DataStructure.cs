using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestVersion.Utilities
{
    public class DataStructure
    {
        [Serializable]//, XmlRoot("GridColumnProperty")]
        public class GridColumnProperty //: IEnumerator
        {
            private int position;

            //public IEnumerator GetEnumerator()
            //{
            //    return (IEnumerator)this;
            //}
            //public bool MoveNext()
            //{
            //    position++;
            //    return (position < this.c);
            //}

            //public void Reset()
            //{
            //    position = 0;
            //}

            //public object Current
            //{
            //    get { return carlist[position]; }
            //}

            [XmlElement("ColumnKey")]
            public string ColumnKey { get; set; }

           
            [XmlElement("DataTypeLength")]
            public int? DataTypeLength { get; set; }

        }

        public class PropertyValue
        {
            public string Name { get; set; }
            public object Value { get; set; }
            public string DisplayText { get; set; }
            public int ImageIndex { get; set; }
        }
        [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
        public sealed class IgnorMappingAttribute : Attribute
        {
            //readonly string name;
            //public IgnorMaping(string name)
            //{
            //    this.name = name;
            //}

            //public string Name
            //{
            //    get { return name; }
            //}
        }

        [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
        public sealed class CustomAttribute : Attribute
        {
            private string displayText;
            private string name;
            private string value;
            private string description;
            public CustomAttribute()
            {

            }
            public string DisplayText
            {
                get { return displayText; }
                set { displayText = value; }
            }
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public string Description
            {
                get { return description; }
                set { description = value; }
            }
            public string Value
            {
                get { return value; }
                set { this.value = value; }
            }
        }

        public class VersionInfo
        {
            public string PackVersionCode { get; set; }
            public string AppVersioCode { get; set; }
            public string UserId { get; set; }
            public ServicePackType PackType { get; set; }
        }

        public class EnumValue
        {
            public object Value { get; set; }
            public string Caption { get; set; }
        }

        public enum DisplayProperty
        {
            Description,
            GroupName,
            Name,
            Prompt,
            ShortName,
            Order
        }

        public enum FormAction
        {
            [Display(Name = "")]
            None,
            [Display(Name = "جدید")]
            Add,
            [Display(Name = "کپی")]
            Copy,
            [Display(Name = "ویرایش")]
            Edit,
            [Display(Name = "مشاهده")]
            View,
            [Display(Name = "حذف")]
            Delete,
            [Display(Name = "گزارش")]
            Report,
            [Display(Name = "انتخاب")]
            Select,
            [Display(Name = "طراحی کوئری-جدید")]
            DesignAdd,
            [Display(Name = "طراحی کوئری-ویرایش")]
            DesignEdit,
            [Display(Name = "مشاهده گزارش")]
            ViewReport
        }

        public enum ServicePackType
        {
            [Display(Name = "هیچکدام")]
            None = 0,
            [Display(Name = "پک از طریق فایل")]
            UserDiffPack = 1,
            [Display(Name = "پک کامل")]
            FullPack = 2,
            [Display(Name = "پک انتخابی")]
            CustomPack = 3,
        }

    }
}
