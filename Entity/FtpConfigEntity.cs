using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    /// <summary>
    /// ftp配置实体类
    /// </summary>
    public class FtpConfigEntity:BaseEntity
    {
        /// <summary>
        /// ftp用户名
        /// </summary>
        public string FtpUserName { get; set; }

        /// <summary>
        /// ftp密码
        /// </summary>
        public string FtpPassword { get; set; }

        /// <summary>
        /// ftp主机地址
        /// </summary>
        public string FtpHost { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime Ctime { get; set; }
    }
}
