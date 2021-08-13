using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace SentryQualityManagement.Core.Entities
{
    public abstract class BaseEntity
    {
        //public int Id { get; set; }

        [NotMapped]
        [Display(AutoGenerateField = false)]
        public object GetValueIdThisObject
        {
            get
            {
                return this.GetType()
                            .GetProperties()
                            .FirstOrDefault(prop => Attribute.IsDefined(prop, typeof(KeyAttribute)))?.GetValue(this, null);
            }
        }

    }
}
