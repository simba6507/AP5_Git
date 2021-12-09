using AP5_New.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AP5_New.Services.IServices
{
    public interface IModuleService
    {
        public List<ModMaster> GetModuleByCondition(ModMaster mod,AP5_NewContext _context);

        public List<ModMaster> GetModuleByOpSearch(ModMaster mod, AP5_NewContext _context);

        public void DeleteSingleModuleByKey(ModMaster mod, AP5_NewContext _context);

        public void InsertUpdateToModMaster(ModMaster mod, AP5_NewContext _context);

        public void DeletefromModMaster(List<ModMaster> deleteList, AP5_NewContext _context);

        public void StartBtnModuleOp(ModMaster mod, AP5_NewContext _context);

        public void EndBtnModuleOp(ModMaster mod, AP5_NewContext _context);

        public List<ModMaster> GetTVModuleData(ModMaster mod, AP5_NewContext _context);
    }
}
