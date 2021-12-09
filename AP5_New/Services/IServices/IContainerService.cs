using AP5_New.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AP5_New.Services.IServices
{
    public interface IContainerService
    {
        public List<ContainerMaster> GetContainerByCondition(ContainerMaster container, AP5_NewContext _context);

        public List<ContainerMaster> GetContainerByOpSearch(ContainerMaster container, AP5_NewContext _context);

        public void DeleteSingleContainerByKey(ContainerMaster mod, AP5_NewContext _context);

        public void InsertUpdateToContainerMaster(ContainerMaster container, AP5_NewContext _context);

        public void DeletefromContainerMaster(List<ContainerMaster> deleteList, AP5_NewContext _context);

        public void StartBtnContainerOp(ContainerMaster container, AP5_NewContext _context);

        public void EndBtnContainerOp(ContainerMaster container, AP5_NewContext _context);

        public List<ContainerMaster> GetTVContainerData(ContainerMaster container, AP5_NewContext _context);
    }
}
