﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Web.Models
{
    public class JqGridData<TEntity>
    {
        private int m_page = 0;
        public int page
        {
            get { return m_page; }
            set { this.m_page = value; }
        }
        /// <summary>
        /// 总页数
        /// </summary>

        public int total
        {
            get
            {
                if (records < 1 || pageSize <= 0)
                    return 0;
                else
                    return (int)Math.Ceiling((float)records / (float)pageSize);

            }
        }
        private int m_pageSize = 0;
        /// <summary>
        /// 每页记录数
        /// </summary>       
        [ScriptIgnore]
        public int pageSize
        {
            get { return m_pageSize; }
            set { this.m_pageSize = value; }
        }

        /// <summary>
        /// 总记录数
        /// </summary>       
        public int records { get; set; }
        public string userdata { get; set; }
        /// <summary>
        /// 行数据
        /// </summary>      
        public IList<TEntity> rows { get; set; }
    }
}