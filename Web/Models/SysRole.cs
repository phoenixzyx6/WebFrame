using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class SysRole
    {
        [Key]
        public virtual int ID { get; set; }
        public virtual string RoleName { get; set; }
        public virtual string RoleDesc { get; set; }
    }
}