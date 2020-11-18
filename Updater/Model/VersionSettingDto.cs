using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Updater.Model
{
    public class VersionSettingDto
    {
        [Column(TypeName = "int")]
        public int ID { get; set; }


        [MaxLength(150)]
        [Column(TypeName = "varchar")]
        public string SettingKey { get; set; }


        [MaxLength(500)]
        [Column(TypeName = "nvarchar")]
        public string SettingValue { get; set; }


        [MaxLength(500)]
        [Column(TypeName = "nvarchar")]
        public string SettingDescription { get; set; }
    }
}
