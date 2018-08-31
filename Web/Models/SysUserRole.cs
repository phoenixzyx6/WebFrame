using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class SysUserRole
    {
        [Key]
        public virtual int ID { get; set; }
        public virtual string UserName { get; set; }
        public virtual int SysRoleID { get; set; }
        public virtual Users Users { get; set; }
        public virtual SysRole SysRole { get; set; }
    }
}