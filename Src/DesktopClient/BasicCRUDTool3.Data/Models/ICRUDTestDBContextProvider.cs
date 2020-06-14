using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCRUDTool3.Data.Models
{
    public interface ICRUDTestDBContextProvider
    {
        CRUDTestDBContext GetContext();
    }
}
