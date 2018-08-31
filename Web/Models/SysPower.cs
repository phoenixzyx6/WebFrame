using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class SysPower
    {
        [Key]
        public virtual int ID { get; set; }
        public virtual string SysFuncID { get; set; }
        public virtual int SysRoleID { get; set; }
        public virtual SysRole SysRole { get; set; }
        public virtual SysFunc SysFunc { get; set; }
    }
}