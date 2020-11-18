using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using static TestVersion.Utilities.DataStructure;
using System.Web.Script.Serialization;
//using static Utilities.DataStructure;

namespace TestVersion.Utilities
{
    public static class ExtentionMethod
    {
        public static System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();

        public static IEnumerable<TreeNode> Descendants(this TreeNodeCollection c)
        {
            foreach (var node in c.OfType<TreeNode>())
            {
                yield return node;

                foreach (var child in node.Nodes.Descendants())
                {
                    yield return child;
                }
            }
        }
        public static double ToDouble(this object value)
        {
            try
            {
                return double.Parse(value.ToString());
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static double ToDouble(this object value, double returnValue)
        {
            try
            {
                if (value == null)
                    return returnValue;
                if (double.TryParse(value.ToString(), out var dblOutVlaue))
                    return dblOutVlaue;
                return returnValue;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public static int ToInteger(this object value)
        {
            try
            {
                return Int32.Parse(value.ToString());
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static int ToInteger(this object value, int returnValue)
        {
            try
            {
                if (value == null)
                    return returnValue;
                if (Int32.TryParse(value.ToString(), out var intOutVlaue))
                    return intOutVlaue;
                return returnValue;
            }
            catch (Exception)
            {
                return returnValue;
            }
        }
        public static string FormatWith(this string format, IFormatProvider provider, object arg0)
        {
            object[] args = new object[] { arg0 };
            return format.FormatWith(provider, args);
        }
        public static int? ToNullableInteger(this object value, int? returnValue)
        {
            try
            {
                if (value == null)
                    return returnValue;
                if (Int32.TryParse(value.ToString(), out var intOutVlaue))
                    return intOutVlaue;
                return returnValue;
            }
            catch (Exception)
            {
                return returnValue;
            }
        }
        public static int? ToNullableInteger(this object value)
        {
            try
            {
                return Int32.Parse(value.ToString());
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static short ToShort(this object value, short returnValue)
        {
            try
            {
                if (value == null)
                    return returnValue;
                if (Int16.TryParse(value.ToString(), out var intOutVlaue))
                    return intOutVlaue;
                return returnValue;
            }
            catch (Exception)
            {
                return returnValue;
            }
        }
        public static short ToShort(this object value)
        {
            try
            {
                return Int16.Parse(value.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static short? ToNullableShort(this object value, short? returnValue)
        {
            try
            {
                if (value == null)
                    return returnValue;
                if (Int16.TryParse(value.ToString(), out var intOutVlaue))
                    return intOutVlaue;
                return returnValue;
            }
            catch (Exception)
            {
                return returnValue;
            }
        }
        public static Guid ToGuid(this object value, Guid returnValue)
        {
            try
            {
                if (value == null)
                    return returnValue;
                if (Guid.TryParse(value.ToString(), out var intOutVlaue))
                    return intOutVlaue;
                return returnValue;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static Guid ToGuid(this object value)
        {
            try
            {
                return Guid.Parse(value.ToString());
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static byte ToByte(this object value)
        {
            try
            {
                return byte.Parse(value.ToString());
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static ushort ToUShort(this object value)
        {
            try
            {
                return UInt16.Parse(value.ToString());
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static float ToFloat(this object value)
        {
            try
            {
                return float.Parse(value.ToString());
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Int64 ToLong(this object value)
        {
            try
            {
                return Int64.Parse(value.ToString());
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool IsNumericalDataType(this string value)
        {
            try
            {
                value = value.ToLower();
                return value == "bit" || value == "tinyint" || value == "smalint" || value == "int" || value == "bigint" || value == "decimal" || value == "numeric" || value == "smalmoney" || value == "money" || value == "float" || value == "real";
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool IsTextualDataType(this string value)
        {
            try
            {
                value = value.ToLower();
                return value == "char" || value == "varchar" || value == "text" || value == "nchar" || value == "nvarchar" || value == "ntext";
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool IsDateTimeDataType(this string value)
        {
            try
            {
                value = value.ToLower();
                return value == "datetime" || value == "datetime2" || value == "smalldatetime" || value == "date" || value == "time" || value == "datetimeoffset" || value == "timestam";
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool IsNumeric(this object value)
        {
            try
            {
                if (value == null)
                    return false;
                return double.TryParse(value.ToString(), out var OutVlaue);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static string ToString(this object value, string onErrorValue = "")
        {
            try
            {
                return value.ToString();
            }
            catch (Exception)
            {
                return onErrorValue;

            }
        }
        public static bool ToBoolean(this object value, bool returnValue = false)
        {
            try
            {
                if (value == null || value == DBNull.Value)
                    return returnValue;

                if (bool.TryParse(value.ToString(), out var OutVlaue))
                    return OutVlaue;
                return returnValue;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable ToDataTable<TSource>(this IEnumerable<TSource> source, Dictionary<string, string> tableColumns)
        {
            System.Data.DataTable dataTable = new System.Data.DataTable(typeof(TSource).Name);
            var props = typeof(TSource).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(w => !Attribute.IsDefined(w, typeof(IgnorMappingAttribute)));
            foreach (var col in tableColumns)
            {
                dataTable.Columns.Add(col.Key);
            }
            foreach (TSource item in source)
            {
                var values = new List<object>();
                var row = dataTable.NewRow();
                foreach (var col in tableColumns)
                {
                    foreach (var prp in props.Where(w => col.Value == w.Name))
                    {
                        if (prp.GetValue(item, null) != null)
                            row[col.Key] = prp.GetValue(item, null);
                        else
                            row[col.Key] = DBNull.Value;
                    }
                }
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }
        public static DataTable ToDataTable<TSource>(this IEnumerable<TSource> source)
        {

            System.Data.DataTable dataTable = new System.Data.DataTable(typeof(TSource).Name);

            var props = typeof(TSource)
                        .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                        .Where(w => !w.IsDefined(typeof(IgnorMappingAttribute)));

            var HaveId = props.Any(w => w.Name.Equals("Id", StringComparison.OrdinalIgnoreCase));

            if (HaveId)
                dataTable.Columns.Add("Id", typeof(int));

            //props.Where(w=>w.Name.Equals("Id")).del
            foreach (PropertyInfo prop in props.Where(w =>/* HaveId && */!w.Name.Equals("Id", StringComparison.OrdinalIgnoreCase)))
            {
                var propertyType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                if (propertyType.BaseType == typeof(Enum))
                    dataTable.Columns.Add(prop.Name, typeof(byte));
                else
                    dataTable.Columns.Add(prop.Name, propertyType);
            }
            //int index = 0;
            foreach (TSource item in source)
            {
                //var values = new List<object>();//[props.Count()];

                //if (HaveId)
                //    values.Add(props.Where(w => w.Name.Equals("Id", StringComparison.OrdinalIgnoreCase)).First().GetValue(item, null));

                DataRow dr = dataTable.NewRow();
                if (HaveId)
                    dr["Id"] = props.Where(w => w.Name.Equals("Id", StringComparison.OrdinalIgnoreCase)).First().GetValue(item, null);

                foreach (var prp in props.Where(w => /*HaveId &&*/ !w.Name.Equals("Id", StringComparison.OrdinalIgnoreCase)))
                {
                    var propertyType = Nullable.GetUnderlyingType(prp.PropertyType) ?? prp.PropertyType;
                if (prp.GetValue(item, null) != null)
                        dr[prp.Name] = prp.GetValue(item, null);
                    else
                        dr[prp.Name] = DBNull.Value;
                }

                dataTable.Rows.Add(dr);
            }
            return dataTable;
        }
        public static DataTable ToDataTable<TSource, TResultStruct>(this IEnumerable<TSource> source) where TResultStruct : new()
        {
            return source.ToXList<TSource, TResultStruct>()
                         .ToDataTable();
        }
        public static List<TResult> ToList<TResult>(this DataTable dataTable) where TResult : new()
        {
            return dataTable.ToXList<TResult>().ToList<TResult>();

            //var dataList = new List<TResult>();

            //const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic;

            //var objFieldNames = (from PropertyInfo aProp in typeof(TResult).GetProperties(flags)
            //                     select aProp.Name);

            //var dataTblFieldNames = (from DataColumn aHeader in dataTable.Columns
            //                         select aHeader.ColumnName);

            //var commonFields = objFieldNames.Intersect(dataTblFieldNames, StringComparer.OrdinalIgnoreCase).ToList();

            //foreach (DataRow dataRow in dataTable.Rows)
            //{
            //    var aTSource = new TResult();
            //    foreach (var aField in commonFields)
            //    {
            //        try
            //        {
            //            var value = dataRow[aField];

            //            if (value == null || value == DBNull.Value)
            //                continue;

            //            PropertyInfo propertyInfos = aTSource.GetType().GetProperty(aField, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            //            var propertyType = propertyInfos.PropertyType;

            //            var IsNullable = Nullable.GetUnderlyingType(propertyType);

            //            if (IsNullable != null)
            //            {
            //                if (IsNullable.IsEnum)
            //                {
            //                    if (IsNullable.Name == nameof(SqlDataType))
            //                        propertyInfos.SetValue(aTSource, value.ToEnum<SqlDataType>(), null);
            //                    else if (IsNullable.Name == nameof(SqlTableType))
            //                        propertyInfos.SetValue(aTSource, value.ToEnum<SqlTableType>(), null);
            //                    else if (IsNullable.Name == nameof(ConvertFunction))
            //                        propertyInfos.SetValue(aTSource, value.ToEnum<ConvertFunction>(), null);
            //                    else if (IsNullable.Name == nameof(ReportColumnType))
            //                        propertyInfos.SetValue(aTSource, value.ToEnum<ReportColumnType>(), null);
            //                    else if (IsNullable.Name == nameof(JoinType))
            //                        propertyInfos.SetValue(aTSource, value.ToEnum<JoinType>(), null);
            //                }
            //                else
            //                    propertyInfos.SetValue(aTSource, Convert.ChangeType(value, Nullable.GetUnderlyingType(propertyType)), null);
            //            }
            //            else if (propertyInfos.PropertyType == typeof(SqlDataType))
            //                propertyInfos.SetValue(aTSource, value.ToEnum<SqlDataType>(), null);
            //            else if (propertyInfos.PropertyType == typeof(SqlTableType))
            //                propertyInfos.SetValue(aTSource, value.ToEnum<SqlTableType>(), null);
            //            else if (propertyInfos.PropertyType == typeof(ConvertFunction))
            //                propertyInfos.SetValue(aTSource, value.ToEnum<ConvertFunction>(), null);
            //            else if (propertyInfos.PropertyType == typeof(ReportColumnType))
            //                propertyInfos.SetValue(aTSource, value.ToEnum<ReportColumnType>(), null);
            //            else if (propertyInfos.PropertyType == typeof(JoinType))
            //                propertyInfos.SetValue(aTSource, value.ToEnum<JoinType>(), null);
            //            else if (propertyInfos.PropertyType == typeof(Color))//.Contains("Color"))
            //            {
            //                propertyInfos.SetValue(aTSource, Color.FromName(value.ToString()), null);
            //            }
            //            else if (propertyInfos.PropertyType == typeof(Font)) //.Contains("Font"))
            //            {
            //                propertyInfos.SetValue(aTSource, value.ToFont(), null);
            //            }
            //            else if (propertyInfos.PropertyType == value.GetType())
            //                propertyInfos.SetValue(aTSource, value, null);

            //            if (propertyInfos.Name != "Id"
            //                &&  propertyInfos.Name.Contains("Id")
            //                && !propertyInfos.Name.Contains("fk_"))
            //            {
            //               //var prop = objFieldNames.Where(w => w == propertyInfos.Name.Left(propertyInfos.Name.Length - 2)).FirstOrDefault();
            //                var prop = objFieldNames.Where(e => e != "Id" 
            //                                                    && e != propertyInfos.Name 
            //                                                    && propertyInfos.Name.Contains(e)).FirstOrDefault();

            //                if (!string.IsNullOrEmpty(prop))
            //                {
            //                    propertyInfos = aTSource.GetType().GetProperty(prop, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            //                    if (propertyInfos.PropertyType == typeof(SqlDataType))
            //                        propertyInfos.SetValue(aTSource, value.ToEnum<SqlDataType>(), null);

            //                    else if (propertyInfos.PropertyType == typeof(SqlTableType))
            //                        propertyInfos.SetValue(aTSource, value.ToEnum<SqlTableType>(), null);

            //                    else if (propertyInfos.PropertyType == typeof(ConvertFunction))
            //                        propertyInfos.SetValue(aTSource, value.ToEnum<ConvertFunction>(), null);

            //                    else if (propertyInfos.PropertyType == typeof(ReportColumnType))
            //                        propertyInfos.SetValue(aTSource, value.ToEnum<ReportColumnType>(), null);

            //                    else if (propertyInfos.PropertyType == typeof(JoinType))
            //                        propertyInfos.SetValue(aTSource, value.ToEnum<JoinType>(), null);

            //                }
            //            }

            //        }
            //        catch (Exception ex)
            //        {
            //            //throw;
            //        }
            //    }
            //    dataList.Add(aTSource);
            //}
            //return dataList;

            ////bool IsNullable(Type type) => Nullable.GetUnderlyingType(type) != null;


        }
        public static List<TResult> ToXList<TResult>(this DataTable dataTable) where TResult : new()
        {
            var dataList = new List<TResult>();

            const BindingFlags flags = BindingFlags.SetField | BindingFlags.SetProperty | BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic;

            var objFieldNames = (from PropertyInfo aProp in typeof(TResult).GetProperties(flags)
                                 select aProp.Name);

            var dataTblFieldNames = (from DataColumn aHeader in dataTable.Columns
                                     select aHeader.ColumnName);

            var commonFields = objFieldNames.Intersect(dataTblFieldNames, StringComparer.OrdinalIgnoreCase).ToList();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                var result = new TResult();
                foreach (var field in commonFields)
                {
                    try
                    {
                        var value = dataRow[field];

                        result.SetValue(field, value, commonFields);

                        #region Old

                        //continue;
                        //PropertyInfo propertyInfos = result.GetType()
                        //                                   .GetProperty(field, BindingFlags.IgnoreCase |
                        //                                                        BindingFlags.Public |
                        //                                                        BindingFlags.Instance);
                        //if (propertyInfos.SetMethod == null)
                        //    continue;

                        //var propertyType = propertyInfos.PropertyType;

                        //var IsNullable = Nullable.GetUnderlyingType(propertyType);

                        //if (IsNullable != null)
                        //{
                        //    if (IsNullable.IsEnum)
                        //    {
                        //        if (IsNullable.Name == nameof(SqlDataType))
                        //            propertyInfos.SetValue(result, value.ToEnum<SqlDataType>(), null);
                        //        else if (IsNullable.Name == nameof(SqlTableType))
                        //            propertyInfos.SetValue(result, value.ToEnum<SqlTableType>(), null);
                        //        else if (IsNullable.Name == nameof(ConvertFunction))
                        //            propertyInfos.SetValue(result, value.ToEnum<ConvertFunction>(), null);
                        //        else if (IsNullable.Name == nameof(ReportColumnType))
                        //            propertyInfos.SetValue(result, value.ToEnum<ReportColumnType>(), null);
                        //        else if (IsNullable.Name == nameof(JoinType))
                        //            propertyInfos.SetValue(result, value.ToEnum<JoinType>(), null);
                        //        else if (IsNullable.Name == nameof(ColumnSortType))
                        //            propertyInfos.SetValue(result, value.ToEnum<ColumnSortType>(), null);
                        //        else if (IsNullable.Name == nameof(ParameterType))
                        //            propertyInfos.SetValue(result, value.ToEnum<ParameterType>(), null);
                        //    }
                        //    else
                        //        propertyInfos.SetValue(result, Convert.ChangeType(value, Nullable.GetUnderlyingType(propertyType)), null);
                        //}
                        //else if (propertyInfos.PropertyType == typeof(SqlDataType))
                        //    propertyInfos.SetValue(result, value.ToEnum<SqlDataType>(), null);
                        //else if (propertyInfos.PropertyType == typeof(SqlTableType))
                        //    propertyInfos.SetValue(result, value.ToEnum<SqlTableType>(), null);
                        //else if (propertyInfos.PropertyType == typeof(ConvertFunction))
                        //    propertyInfos.SetValue(result, value.ToEnum<ConvertFunction>(), null);
                        //else if (propertyInfos.PropertyType == typeof(ReportColumnType))
                        //    propertyInfos.SetValue(result, value.ToEnum<ReportColumnType>(), null);
                        //else if (propertyInfos.PropertyType == typeof(JoinType))
                        //    propertyInfos.SetValue(result, value.ToEnum<JoinType>(), null);
                        //else if (propertyInfos.PropertyType == typeof(ColumnSortType))
                        //    propertyInfos.SetValue(result, value.ToEnum<ColumnSortType>(), null);
                        //else if (propertyInfos.PropertyType == typeof(ParameterType))
                        //    propertyInfos.SetValue(result, value.ToEnum<ParameterType>(), null);
                        //else if (propertyInfos.PropertyType == typeof(Color))//.Contains("Color"))
                        //{
                        //    if (value.ToString().Contains("#"))
                        //        propertyInfos.SetValue(result, ColorTranslator.FromHtml(value.ToString()), null);
                        //    else
                        //        propertyInfos.SetValue(result, Color.FromName(value.ToString()), null);
                        //}
                        //else if (propertyInfos.PropertyType == typeof(Font)) //.Contains("Font"))
                        //{
                        //    propertyInfos.SetValue(result, value.ToFont(), null);
                        //}
                        //else if (propertyInfos.PropertyType == typeof(object) || propertyInfos.PropertyType == value.GetType())
                        //    propertyInfos.SetValue(result, value, null);

                        //if (propertyInfos.Name != "Id"
                        //    && propertyInfos.Name.Contains("Id")
                        //    && !propertyInfos.Name.Contains("fk_"))
                        //{
                        //    //var prop = objFieldNames.Where(w => w == propertyInfos.Name.Left(propertyInfos.Name.Length - 2)).FirstOrDefault();
                        //    var prop = commonFields.Where(e => e != "Id"
                        //                                        && e != propertyInfos.Name
                        //                                        && propertyInfos.Name.Contains(e)).FirstOrDefault();

                        //    if (!string.IsNullOrEmpty(prop))
                        //    {
                        //        propertyInfos = result.GetType().GetProperty(prop, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                        //        if (propertyInfos.PropertyType == typeof(SqlDataType))
                        //            propertyInfos.SetValue(result, value.ToEnum<SqlDataType>(), null);
                        //        else if (propertyInfos.PropertyType == typeof(SqlTableType))
                        //            propertyInfos.SetValue(result, value.ToEnum<SqlTableType>(), null);
                        //        else if (propertyInfos.PropertyType == typeof(ConvertFunction))
                        //            propertyInfos.SetValue(result, value.ToEnum<ConvertFunction>(), null);
                        //        else if (propertyInfos.PropertyType == typeof(ReportColumnType))
                        //            propertyInfos.SetValue(result, value.ToEnum<ReportColumnType>(), null);
                        //        else if (propertyInfos.PropertyType == typeof(JoinType))
                        //            propertyInfos.SetValue(result, value.ToEnum<JoinType>(), null);
                        //        else if (propertyInfos.PropertyType == typeof(ColumnSortType))
                        //            propertyInfos.SetValue(result, value.ToEnum<ColumnSortType>(), null);
                        //        else if (propertyInfos.PropertyType == typeof(ParameterType))
                        //            propertyInfos.SetValue(result, value.ToEnum<ParameterType>(), null);
                        //    }
                        //}
                        #endregion

                    }
                    catch (Exception ex)
                    {
                        //throw;
                    }
                }
                dataList.Add(result);
            }
            return dataList;
        }
        public static void SetValue<TResult>(this TResult resultObject, string field, object value, IEnumerable<string> fieldList)
        {
            if (value == null || value == DBNull.Value)
                return;
            PropertyInfo propertyInfos = resultObject.GetType()
                                                     .GetProperty(field, BindingFlags.IgnoreCase |
                                                                         BindingFlags.Public |
                                                                         BindingFlags.Instance);
            if (propertyInfos.SetMethod == null)
                return;

            var propertyType = propertyInfos.PropertyType;
            var isNullable = Nullable.GetUnderlyingType(propertyType);

            if (isNullable != null)
            {
                
                    propertyInfos.SetValue(resultObject, Convert.ChangeType(value, Nullable.GetUnderlyingType(propertyType)), null);
            }
            
            else if (propertyInfos.PropertyType == typeof(Color))//.Contains("Color"))
            {
                if (value.ToString().Contains("#"))
                    propertyInfos.SetValue(resultObject, ColorTranslator.FromHtml(value.ToString()), null);
                else
                    propertyInfos.SetValue(resultObject, Color.FromName(value.ToString()), null);
            }
            else if (propertyInfos.PropertyType == typeof(Font)) //.Contains("Font"))
            {
                propertyInfos.SetValue(resultObject, value.ToFont(), null);
            }
            else if (propertyInfos.PropertyType == typeof(object) || propertyInfos.PropertyType == value.GetType())
                propertyInfos.SetValue(resultObject, value, null);

            
        }
        public static TDto ToDto<TEntity, TDto>(this TEntity sources) where TDto : new()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TEntity, TDto>();
            });
            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<TEntity, TDto>(sources);
        }
        public static List<TDestination> ToXList<TSource, TDestination>(this IEnumerable<TSource> sources) where TDestination : new()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();
            });
            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<IEnumerable<TSource>, List<TDestination>>(sources);

        }
        public static List<TSource> ToXList<TSource>(this IEnumerable<TSource> sources) where TSource : new()
        {
            var dataList = new List<TSource>();

            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic;

            var objFieldNames = (from PropertyInfo aProp in typeof(TSource).GetProperties(flags)
                                 select aProp.Name);

            //var dataTblFieldNames = (from DataColumn aHeader in dataTable.Columns
            //                         select aHeader.ColumnName);

            //var commonFields = objFieldNames.Intersect(dataTblFieldNames, StringComparer.OrdinalIgnoreCase).ToList();

            foreach (TSource dataRow in sources)
            {
                var aTSource = new TSource();
                foreach (var aField in objFieldNames)
                {
                    try
                    {
                        PropertyInfo propertyInfos = aTSource.GetType().GetProperty(aField, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                        if (propertyInfos.SetMethod == null)
                            continue;

                        var value = propertyInfos.GetValue(dataRow, null);
                        propertyInfos.SetValue(aTSource, value, null);
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
                dataList.Add(aTSource);
            }
            return dataList;


        }
        public static SqlDbType ToSqlDbType(this object value)
        {
            try
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                return (SqlDbType)Enum.Parse(typeof(SqlDbType), value.ToString().ToUpper(), true);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool HasValue(this string value, bool ignoreWhiteSpace = true)
        {
            return ignoreWhiteSpace ? !string.IsNullOrWhiteSpace(value) : !string.IsNullOrEmpty(value);
        }
        public static int ToInt(this string value)
        {
            return Convert.ToInt32(value);
        }
        public static decimal ToDecimal(this object value, decimal returnValue = 0)
        {
            try
            {
                if (decimal.TryParse(value.ToString(), out var intOutVlaue))
                    return intOutVlaue;
                return returnValue;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string ToNumeric(this int value)
        {
            return value.ToString("N0"); //"123,456"
        }

        public static string ToNumeric(this decimal value)
        {
            return value.ToString("N0");
        }

        public static string ToCurrency(this int value)
        {
            //fa-IR => current culture currency symbol => ریال
            //123456 => "123,123ریال"
            return value.ToString("C0");
        }

        public static string ToCurrency(this decimal value)
        {
            return value.ToString("C0");
        }

        public static string En2Fa(this string str)
        {
            return str.Replace("0", "۰")
                .Replace("1", "۱")
                .Replace("2", "۲")
                .Replace("3", "۳")
                .Replace("4", "۴")
                .Replace("5", "۵")
                .Replace("6", "۶")
                .Replace("7", "۷")
                .Replace("8", "۸")
                .Replace("9", "۹");
        }

        public static string Fa2En(this string str)
        {
            return str.Replace("۰", "0")
                .Replace("۱", "1")
                .Replace("۲", "2")
                .Replace("۳", "3")
                .Replace("۴", "4")
                .Replace("۵", "5")
                .Replace("۶", "6")
                .Replace("۷", "7")
                .Replace("۸", "8")
                .Replace("۹", "9")
                //iphone numeric
                .Replace("٠", "0")
                .Replace("١", "1")
                .Replace("٢", "2")
                .Replace("٣", "3")
                .Replace("٤", "4")
                .Replace("٥", "5")
                .Replace("٦", "6")
                .Replace("٧", "7")
                .Replace("٨", "8")
                .Replace("٩", "9");
        }

        public static string FixPersianChars(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            return str.Replace("ﮎ", "ک")
                .Replace("ﮏ", "ک")
                .Replace("ﮐ", "ک")
                .Replace("ﮑ", "ک")
                .Replace("ك", "ک")
                .Replace("ي", "ی")
                .Replace(" ", " ")
                .Replace("‌", " ")
                .Replace("ھ", "ه");//.Replace("ئ", "ی");
        }

        public static string CleanString(this string str)
        {
            return str.Trim().FixPersianChars().Fa2En().NullIfEmpty();
        }

        public static string NullIfEmpty(this string str)
        {
            return str?.Length == 0 ? null : str;
        }
        public static class FontXmlConverter
        {
            public static string ConvertToString(System.Drawing.Font font)
            {
                try
                {
                    if (font != null)
                    {
                        TypeConverter converter = TypeDescriptor.GetConverter(typeof(System.Drawing.Font));
                        return converter.ConvertToString(font);
                    }
                    else
                        return null;
                }
                catch { System.Diagnostics.Debug.WriteLine("Unable to convert"); }
                return null;
            }
            public static System.Drawing.Font ConvertToFont(string fontString)
            {
                try
                {
                    TypeConverter converter = TypeDescriptor.GetConverter(typeof(System.Drawing.Font));
                    return (System.Drawing.Font)converter.ConvertFromString(fontString);
                }
                catch { System.Diagnostics.Debug.WriteLine("Unable to convert"); }
                return null;
            }

            public static Font ConvertToFont(object headerFont)
            {
                throw new NotImplementedException();
            }
        }
        public static T NotNull<T>(this T obj, string name, string message = null)
           where T : class
        {
            if (obj is null)
                throw new ArgumentNullException($"{name} : {typeof(T)}", message);
            return obj;
        }
        public static T? NotNull<T>(this T? obj, string name, string message = null)
            where T : struct
        {
            if (!obj.HasValue)
                throw new ArgumentNullException($"{name} : {typeof(T)}", message);
            return obj;
        }
        public static T NotEmpty<T>(this T obj, string name, string message = null, T defaultValue = null)
            where T : class
        {
            if (obj == defaultValue
                || (obj is string str && string.IsNullOrWhiteSpace(str))
                || (obj is IEnumerable<T> list && !list.Cast<object>().Any()))
            {
                throw new ArgumentException("Argument is empty : " + message, $"{name} : {typeof(T)}");
            }
            return obj;
        }
        public static bool IsDateValid(this object persianDate)
        {
            try
            {

                DateTime.Parse(persianDate.ToString(), new System.Globalization.CultureInfo("fa-IR")).ToUniversalTime();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public static DateTime ToGregorianDate(this object persianDate)
        {
            return DateTime.Parse(persianDate.ToString(), new System.Globalization.CultureInfo("fa-IR")).ToUniversalTime();
        }
        public static string ToPersianDate(this object gregorianDate)
        {
            if (gregorianDate == null)
                return "";
            DateTime dateTime = new DateTime();
            if (!DateTime.TryParse(gregorianDate.ToString(), out dateTime))
                return "";
            return $"{pc.GetYear(dateTime)}/{("0" + pc.GetMonth(dateTime).ToString()).Right(2)}/{("0" + pc.GetDayOfMonth(dateTime)).Right(2)}";
        }
        public static string Left(this string str, int length)
        {
            str = (str ?? string.Empty);
            return str.Substring(0, Math.Min(length, str.Length));
        }
        public static string Right(this string str, int length)
        {
            str = (str ?? string.Empty);
            return (str.Length >= length)
                ? str.Substring(str.Length - length, length)
                : str;
        }
        public static IEnumerable<PropertyValue> GetPropertiesByAttribute<T>(this object value, Type attribute) where T : class
        {
            var displayText = "";
            var props = typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(prop => Attribute.IsDefined(prop, attribute));
            foreach (var prop in props)
            {
                if (attribute == typeof(CustomAttribute))
                {
                    var myAttribute = prop.GetCustomAttributes<CustomAttribute>().FirstOrDefault();
                    if (myAttribute != null)
                        displayText = myAttribute.DisplayText;
                }
                yield return new PropertyValue
                {
                    Name = prop.Name,
                    Value = prop.GetValue(value),
                    DisplayText = displayText
                };
            }
        }
        public static IEnumerable<PropertyValue> GetEnumFieldByAttribute<T>(this Enum value, Type attribute) where T : Enum
        {
            var props = typeof(T).GetProperties().Where(prop => Attribute.IsDefined(prop, attribute));
            foreach (var item in props)
            {
                yield return new PropertyValue { Name = item.Name, Value = item.GetValue(value) };
            }
        }
        public static int LevelPathCompare(string levelPath1, string levelPath2)
        {
            var item1 = levelPath1.Split('.');
            var item2 = levelPath2.Split('.');
            if (item1.Length < item2.Length)
            {
                for (int i = 0; i < item1.Length; i++)
                {
                    if (item1[i].ToInteger() > item2[i].ToInteger())
                    {
                        return 1;
                    }
                    else if (item1[i].ToInteger() < item2[i].ToInteger())
                    {
                        return -1;
                    }
                }
                return -1;
            }
            else if (item1.Length > item2.Length)
            {
                for (int i = 0; i < item2.Length; i++)
                {
                    if (item1[i].ToInteger() > item2[i].ToInteger())
                    {
                        return 1;
                    }
                    else if (item1[i].ToInteger() < item2[i].ToInteger())
                    {
                        return -1;
                    }
                }
            }
            else
            {
                for (int i = 0; i < item2.Length; i++)
                {
                    if (item1[i].ToInteger() > item2[i].ToInteger())
                    {
                        return 1;
                    }
                    else if (item1[i].ToInteger() < item2[i].ToInteger())
                    {
                        return -1;
                    }
                }
            }
            return 0;
        }
        public static List<T> ToOjectList<T>(this XElement element) where T : class, new()
        {
            try
            {
                if (element == null)
                    return default(List<T>);

                var serializer = new XmlSerializer(typeof(List<T>));
                var x = (List<T>)serializer.Deserialize(element.CreateReader());

                return x;
            }
            catch (Exception ex)
            {
                return default(List<T>);
            }
        }
        /// <summary>
        /// Serializes an object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serializableObject"></param>
        /// <param name="fileName"></param>
        public static void SerializeToFile<T>(this T serializableObject, string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException(nameof(fileName));

            if (serializableObject == null) { return; }

            try
            {
                XmlDocument xmlDocument = new XmlDocument() { XmlResolver = null };
                XmlSerializer serializer = new XmlSerializer(serializableObject.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, serializableObject);
                    stream.Position = 0;
                    using (XmlReader reader = XmlReader.Create(stream, new XmlReaderSettings() { XmlResolver = null }))
                    {
                        if (!File.Exists(fileName))
                            Directory.CreateDirectory(fileName.Substring(0, fileName.LastIndexOf('\\')));
                        xmlDocument.Load(reader);
                        xmlDocument.Save(fileName);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
                //Log exception here
            }
        }
        /// <summary>
        /// Deserializes an xml file into an object list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static T DeSerializeFromFile<T>(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) { return default(T); }

            T objectOut = default(T);

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                string xmlString = xmlDocument.OuterXml;

                using (StringReader read = new StringReader(xmlString))
                {
                    Type outType = typeof(T);

                    XmlSerializer serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        objectOut = (T)serializer.Deserialize(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
                //Log exception here
            }

            return objectOut;
        }
        public static T ToObject<T>(this XElement element) where T : class, new()
        {
            try
            {
                if (element == null)
                    return default(T);

                var serializer = new XmlSerializer(typeof(T));
                var x = (T)serializer.Deserialize(element.CreateReader());

                return x;
            }
            catch (Exception ex)
            {
                return default(T);
            }

            //try
            //{
            //    T instance = new T();
            //    foreach (var property in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(w => Attribute.IsDefined(w, typeof(MyAttribute))))
            //    {
            //        var xattribute = element.Attribute(property.Name);
            //        var xelement = element.Element(property.Name);
            //        var propertyType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
            //        var value = xattribute?.Value ?? xelement.Value;

            //        try
            //        {
            //            if (value != null)
            //            {
            //                if (property.CanWrite)
            //                {
            //                    property.SetValue(instance, Convert.ChangeType(value, propertyType));
            //                }
            //            }
            //        }
            //        catch // (Exception ex) // If Error let the value remain default for that property type
            //        {
            //            Console.WriteLine("Not able to parse value " + value + " for type '" + property.PropertyType + "' for property " + property.Name);
            //        }
            //    }
            //    return instance;
            //}
            //catch (Exception ex)
            //{
            //    return default(T);
            //}
        }
        public static T ToObject<T>(this string element) where T : class, new()
        {
            try
            {
                if (string.IsNullOrEmpty(element))
                    return default(T);

                var xElement = XElement.Parse(element);

                var serializer = new XmlSerializer(typeof(T));
                var x = (T)serializer.Deserialize(xElement.CreateReader());

                return x;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
        public static Font ToFont(this object font)
        {
            if (font == null || string.IsNullOrEmpty(font.ToString()))
                return null;

            var cvt = new FontConverter();
            return cvt.ConvertFromString(font.ToString()) as Font;
        }
        public static T GetValue<T>(this Janus.Windows.GridEX.GridEXRow dataRow) where T : new()
        {
            if (dataRow == null)
                throw new ArgumentNullException(nameof(dataRow));

            const BindingFlags flags = BindingFlags.SetField | BindingFlags.SetProperty | BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic;

            var objFieldNames = (from PropertyInfo aProp in typeof(T).GetProperties(flags)
                                 select aProp.Name);

            var gridColumns = (from Janus.Windows.GridEX.GridEXColumn column in dataRow.GridEX.RootTable.Columns
                               select column.DataMember);

            var commonFields = objFieldNames.Intersect(gridColumns, StringComparer.OrdinalIgnoreCase).ToList();

            var aTSource = new T();
            foreach (var column in commonFields)
            {
                var value = dataRow.Cells[column].Value;

                if (value == null || value == DBNull.Value)
                    continue;
                PropertyInfo propertyInfos = aTSource.GetType().GetProperty(column);
                propertyInfos.SetValue(aTSource, value, null);
            }
            return aTSource;
        }

        public static string ToJSON(this object obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(obj);
        }

    }
    public static class MemberInfoExtensions
    {
        public static bool IsAttributeDefined<TAttribute>(this MemberInfo memberInfo)
        {
            return memberInfo.IsAttributeDefined(typeof(TAttribute));
        }

        public static bool IsAttributeDefined(this MemberInfo memberInfo, Type attributeType)
        {
            return memberInfo.GetCustomAttribute(attributeType, true) != null;
        }
    }

    

}
