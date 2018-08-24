using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheatSheet.Database
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            CreatedOn = DateTime.Now;
            UpdatedOn = DateTime.Now;
            State = EntityState.New;
        }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }

        [NotMapped]
        public EntityState State { get; set; }

        public enum EntityState
        {
            New = 1,
            Update = 2,
            Delete = 3,
            Ignore = 4
        }
    }
}