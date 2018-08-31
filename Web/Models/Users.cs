using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class Users
    {
        [StringLength(10, MinimumLength = 2)]
        [DisplayName("用户名")]
        [Required]
        [Key]
        public virtual string UserName { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        [DisplayName("登录密码")]
        [StringLength(50, MinimumLength = 6)]
        [Required]
        public virtual string Password { get; set; }

        public virtual ICollection<SysUserRole> SysUserRoles { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        [DisplayName("真实姓名")]
        [StringLength(30)]
        public virtual string TrueName
        {
            get;
            set;
        }
        /// <summary>
        /// 籍贯
        /// </summary>
        [DisplayName("籍贯")]
        [StringLength(50)]
        public virtual string Nation
        {
            get;
            set;
        }
        /// <summary>
        /// 出生日期
        /// </summary>
        [DisplayName("出生日期")]
        public virtual System.DateTime? Birthday
        {
            get;
            set;
        }
        /// <summary>
        /// 通讯地址
        /// </summary>
        [DisplayName("通讯地址")]
        [StringLength(256)]
        public virtual string CommAddr
        {
            get;
            set;
        }
        /// <summary>
        /// 身份证号
        /// </summary>
        [DisplayName("身份证号")]
        [StringLength(20)]
        public virtual string IDCard
        {
            get;
            set;
        }
        /// <summary>
        /// 血型
        /// </summary>
        [DisplayName("血型")]
        [StringLength(20)]
        public virtual string BloodType
        {
            get;
            set;
        }
        /// <summary>
        /// 性别
        /// </summary>
        [DisplayName("性别")]
        [StringLength(20)]
        public virtual string Sex
        {
            get;
            set;
        }
        /// <summary>
        /// Email
        /// </summary>
        [DisplayName("Email")]
        [StringLength(50)]
        public virtual string Email
        {
            get;
            set;
        }
        /// <summary>
        /// 手机
        /// </summary>
        [DisplayName("手机")]
        [StringLength(20)]
        public virtual string Mobile
        {
            get;
            set;
        }
        /// <summary>
        /// 用户类型
        /// </summary>
        [DisplayName("用户类型")]
        [StringLength(50)]
        public virtual string UserType
        {
            get;
            set;
        }
        /// <summary>
        /// 是否启用
        /// </summary>
        [Required]
        [DisplayName("是否启用")]
        [DefaultValue(true)]
        public virtual bool IsUsed
        {
            get;
            set;
        }
        /// <summary>
        /// 备注
        /// </summary>
        [DisplayName("备注")]
        [StringLength(256)]
        public virtual string Remark
        {
            get;
            set;
        }
    }
}