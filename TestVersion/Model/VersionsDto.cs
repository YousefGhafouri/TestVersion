using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestVersion.Utilities;

namespace TestVersion.Model
{
    public class VersionsDto
    {
        [Column(TypeName = "int")]
        public int ID { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string VersionCode { get; set; }
        [MaxLength(200)]
        [Column(TypeName = "nvarchar")]
        public string VersionName { get; set; }
        [MaxLength(250)]
        [Column(TypeName = "nvarchar")]
        public string DllPath { get; set; }
        [MaxLength(250)]
        [Column(TypeName = "nvarchar")]
        public string StructureScriptPath { get; set; }
        [MaxLength(250)]
        [Column(TypeName = "nvarchar")]
        public string AlterScriptPath { get; set; }
        [MaxLength(500)]
        [Column(TypeName = "nvarchar")]
        public string VersionDescription { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreationDateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EditionDateTime { get; set; }
        public bool IsSelect { get; set; }
        public int VersionCodeInt
        {
            get
            {
                return VersionCode.ToInteger();
            }
        }
    }
}
