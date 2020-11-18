using Janus.Windows.GridEX;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Reflection;
using static TestVersion.Utilities.DataStructure;

namespace TestVersion.Utilities
{

    public static class EnumExtensions
    {
        public static IEnumerable<T> GetEnumValues<T>(this T input) where T : struct
        {
            if (!typeof(T).IsEnum)
                throw new NotSupportedException();

            return Enum.GetValues(input.GetType()).Cast<T>();
        }
        public static List<EnumValue> EnumToList<T>(Func<T, bool> filter = null) where T : Enum
        {
            if (!typeof(T).IsEnum)
                throw new NotSupportedException();
            var list = new List<EnumValue>();
            if (filter != null)
                foreach (PropertyValue item in GetEnumFieldByAttribute<T>().Where(w => filter((T)w.Value)))
                    list.Add(new EnumValue()
                    {
                        Value = item.Value,
                        Caption = item.DisplayText
                    });
            else
                foreach (PropertyValue item in GetEnumFieldByAttribute<T>())
                    list.Add(new EnumValue()
                    {
                        Value = item.Value,
                        Caption = item.DisplayText
                    });
            return list;
        }
        public static T ToEnum<T>(this object enumString) where T : Enum
        {
            if (enumString == null || string.IsNullOrEmpty(enumString.ToString()))
                return (T)Enum.Parse(typeof(T), "0");

            return (T)Enum.Parse(typeof(T), enumString.ToString(), true);
        }
        public static int ToEnumValue<T>(this object enumString) where T : Enum
        {
            if (!typeof(T).IsEnum)
                throw new NotSupportedException();
            if (enumString == null)
                throw new ArgumentNullException(nameof(enumString));

            var enumString1 = enumString.ToString();
            if (enumString1.Contains("("))
            {
                enumString1 = enumString1.Substring(0, enumString1.IndexOf('('));
            }

            return (int)Enum.Parse(typeof(T), enumString1, true);
        }
        public static IEnumerable<T> GetEnumFlags<T>(this T input) where T : struct
        {
            if (!typeof(T).IsEnum)
                throw new NotSupportedException();

            foreach (var value in Enum.GetValues(input.GetType()))
                if ((input as Enum).HasFlag(value as Enum))
                    yield return (T)value;
        }

        public static string ToDisplay(this Enum value, DisplayProperty property = DisplayProperty.Name)
        {
            //value.NotNull(nameof(value));

            var attribute = value.GetType().GetField(value.ToString())
                .GetCustomAttributes<DisplayAttribute>(false).FirstOrDefault();

            if (attribute == null)
                return value.ToString();

            var propValue = attribute.GetType().GetProperty(property.ToString()).GetValue(attribute, null);
            return propValue.ToString();
        }
        public static string GetFieldValue<T>(this object value) where T : Enum
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            var type = typeof(T);
            var fieldValue = type.GetMember(value.ToString())[0].GetCustomAttributes(typeof(CustomAttribute), false);
            if (fieldValue == null)
                return "";
            var attributesValue = ((CustomAttribute)fieldValue[0]).Value;

            if (attributesValue == null)
                return value.ToString();

            return attributesValue.ToString();
        }
        public static Dictionary<int, string> ToDictionary<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToDictionary(p => Convert.ToInt32(p), q => ToDisplay(q));
        }
        public static GridEXValueListItem[] ToValueListItem<T>() where T : Enum
        {
            var list = new List<GridEXValueListItem>();
            foreach (var item in ToDictionary<T>())
                list.Add(new GridEXValueListItem(item.Key, item.Value));

            return list.ToArray();
        }
        public static IEnumerable<PropertyValue> GetEnumFieldByAttribute<T>() where T : Enum
        {
            if (!typeof(T).IsEnum)
                throw new NotSupportedException();

            Type type = typeof(T);
            var props = type.GetEnumValues();
            foreach (var item in props)
            {
                yield return new PropertyValue
                {
                    Name = Enum.GetName(type, item),
                    Value = item,
                    DisplayText = (type.GetMember(type.GetEnumName(item))[0].GetCustomAttributes(typeof(CustomAttribute), false) as CustomAttribute[])[0].DisplayText
                };
            }
        }
        public static DataTable EnumToDataTable<T>(this T enumVlaue) where T : Enum
        {
            if (!typeof(T).IsEnum)
                throw new NotSupportedException();

            DataTable table = new DataTable();
            table.Columns.Add("Value", typeof(string));
            table.Columns.Add("Caption", typeof(string));
            foreach (PropertyValue item in GetEnumFieldByAttribute<T>())
            {
                table.Rows.Add(item.Value, item.DisplayText);
            }
            return table;
        }
    }

}
