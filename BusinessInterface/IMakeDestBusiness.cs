using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace BusinessInterface
{
    public interface IMakeDestBusiness:IBaseBusiness
    {
        /// <summary>
        /// make the dest file
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>bool,true means make success,false means failed</returns>
        bool Make(MakeDestEntity entity);
    }
}
