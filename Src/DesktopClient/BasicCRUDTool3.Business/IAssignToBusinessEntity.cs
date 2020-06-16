using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCRUDTool3.Business
{
    public interface IAssignToBusinessEntity<TBusinessEntity>
    {
        public void AssignTo(TBusinessEntity businessEntity);
    }
}
