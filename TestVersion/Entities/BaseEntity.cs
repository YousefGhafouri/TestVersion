using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVersion.Entities
{
    public interface IEntity { }
    public abstract class BaseEntity<TKey> : IEntity
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //[System.Data.Linq.Mapping.Column(Storage = "Id", DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        [System.Data.Linq.Mapping.Column(Storage = "Id", DbType = "Int NOT NULL", IsPrimaryKey = true, IsDbGenerated = false)]
        public TKey Id { get; set; }
        //public int CreatorUNo { get; set; }
        //public int EditorUNo { get; set; }
        //public DateTime CreationDateTime { get; set; }
        //public DateTime EditationDateTime { get; set; }
    }
    public abstract class BaseEntity : BaseEntity<int>
    {

    }
    public abstract class BaseEntityCE : BaseEntity<int>
    {
        public int CreatorUserId { get; set; }
        public int? EditorUserId { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime? EditationDateTime { get; set; }
    }
}
