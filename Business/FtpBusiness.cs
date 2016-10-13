using System;
using System.Collections.Generic;
using System.Text;
using Business.DestMake;
using BusinessInterface;
using Component;
using DALInterface;

namespace Business
{
    public class FtpBusiness:BaseBusiness,IFtpBusiness
    {

        public List<Entity.FtpConfigEntity> GetFtpConfigHis()
        {
            throw new NotImplementedException();
        }

        public Entity.FtpConfigEntity GetLast()
        {
            var dal = Factory.Instance().GetService<IFtpDal>(); 
            var ftpConfigEntity=dal.SelectLast();
            return ftpConfigEntity;
        }

        public bool AddNew(Entity.FtpConfigEntity entity)
        {
            var dal = Factory.Instance().GetService<IFtpDal>();
            var result= dal.Insert(entity);
            return result > 0;
        }
    }
}
