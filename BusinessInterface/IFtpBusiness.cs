using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace BusinessInterface
{
    public interface IFtpBusiness:IBaseBusiness
    {
        /// <summary>
        /// 获取所有配置历史
        /// </summary>
        /// <returns></returns>
        List<FtpConfigEntity> GetFtpConfigHis();

        /// <summary>
        /// 获取最新的一条配置
        /// </summary>
        /// <returns></returns>
        FtpConfigEntity GetLast();

        /// <summary>
        /// 新增加一条内容
        /// </summary>
        /// <param name="entity">需要增加的ftp配置内容</param>
        /// <returns></returns>
        bool AddNew(FtpConfigEntity entity);
    }
}
