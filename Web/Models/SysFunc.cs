using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Web.Models
{
    public class SysFunc
    {
        [Key]
        public virtual string SysFuncID { get; set; }

        /// <summary>
        /// Url列表，多url的func对应的多个url, 无url返回空和List`1string 
        /// </summary>
        [ScriptIgnore]
        public virtual IList<string> Urls
        {
            get
            {
                if (!string.IsNullOrEmpty(URL))
                {
                    return URL.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(p => p.Trim())
                        .ToList();
                }
                else
                    return new List<string>();
            }
        }

        /// <summary>
        /// 小写Url列表 
        /// </summary>
        [ScriptIgnore]
        public virtual IList<string> LowerUrls
        {
            get
            {
                return Urls.Select(p => p.ToLower()).ToList();
            }
        }

        #region Properties
        /// <summary>
        /// 功能名称
        /// </summary>
        [DisplayName("功能名称")]
        [StringLength(50)]
        public virtual string FuncName
        {
            get;
            set;
        }
        /// <summary>
        /// 功能描述
        /// </summary>
        [DisplayName("功能描述")]
        [StringLength(128)]
        public virtual string FuncDesc
        {
            get;
            set;
        }
        /// <summary>
        /// 父节点
        /// </summary>
        [DisplayName("父节点")]
        [StringLength(50)]
        public virtual string ParentID
        {
            get;
            set;
        }
        /// <summary>
        /// 是否叶子节点
        /// </summary>
        [Required]
        [DisplayName("是否叶子节点")]
        public virtual bool IsLeaf
        {
            get;
            set;
        }
        /// <summary>
        /// 是否按钮
        /// </summary>
        [Required]
        [DisplayName("是否按钮")]
        public virtual bool IsButton
        {
            get;
            set;
        }
        /// <summary>
        /// URL
        /// </summary>
        [DisplayName("URL")]
        [StringLength(1200)]
        public virtual string URL
        {
            get;
            set;
        }
        /// <summary>
        /// 是否禁用
        /// </summary>
        [Required]
        [DisplayName("是否禁用")]
        public virtual bool IsDisabled
        {
            get;
            set;
        }
        /// <summary>
        /// 功能代码
        /// </summary>
        [DisplayName("功能代码")]
        [StringLength(50)]
        public virtual string HandlerName
        {
            get;
            set;
        }
        /// <summary>
        /// 排序
        /// </summary>
        [DisplayName("排序")]
        public virtual int? OrderNum
        {
            get;
            set;
        }
        #endregion
    }
}