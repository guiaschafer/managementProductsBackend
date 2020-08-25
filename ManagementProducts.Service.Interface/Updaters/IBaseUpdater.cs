using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementProducts.Service.Interface.Updaters
{
    public interface IBaseUpdater<T>
    {
        T Save(T dto);
        void Delete(T dto);
        T Update(T dto);
    }
}
