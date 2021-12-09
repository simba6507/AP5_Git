using AP5_New.Models;
using AP5_New.Services.IServices;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AP5_New.Services.ServiceImplement
{
    public class ModuleService : IModuleService
    {
        public List<ModMaster> GetModuleByCondition(ModMaster mod,AP5_NewContext _context)
        {
            //List<ModMaster> resultList = _context.ModMasters
            //    .Where(x => x.UnboxDate == mod.UnboxDate)
            //    .OrderByDescending(x => x.UnboxDate)
            //    .ThenBy(x => x.PlantCode)
            //    .ThenBy(x => x.LineoffCount).ToList();
            try
            {
                List<ModMaster> resultList = (from t in _context.ModMasters
                                              where (t.UnboxDate == mod.UnboxDate || mod.UnboxDate == null)
                                                && (t.UnboxArea == mod.UnboxArea || mod.UnboxArea == 0)
                                                && (t.PlantCode == mod.PlantCode || mod.PlantCode == null)
                                                && (t.Country == mod.Country || mod.Country == null)
                                              orderby t.UnboxDate descending, t.PlantCode ascending, t.ShiftType ascending, t.LineoffCount ascending
                                              select t).ToList();
                return resultList;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public void InsertUpdateToModMaster(ModMaster mod, AP5_NewContext _context)
        {
            try
            {
                ModMaster existMod = (from t in _context.ModMasters
                                      where (t.CarType == mod.CarType)
                                        && (t.Country == mod.Country)
                                        && (t.ModNo == mod.ModNo)
                                      select t).FirstOrDefault();
                if (existMod != null)
                {
                    existMod.PlantCode = mod.PlantCode;
                    existMod.UnboxDate = mod.UnboxDate;
                    existMod.ShiftType = mod.ShiftType;
                    existMod.UnboxArea = mod.UnboxArea;
                    existMod.LineoffCount = mod.LineoffCount;
                    existMod.Mark = mod.Mark;
                    existMod.LogicalTime = mod.LogicalTime;
                    _context.SaveChanges();
                }
                else
                {
                    mod.ModStatus = "未開梱";
                    mod.DoneFlag = "0";
                    _context.ModMasters.Add(mod);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void DeletefromModMaster(List<ModMaster> deleteList, AP5_NewContext _context)
        {

            try
            {
                foreach (var item in deleteList)
                {
                    _context.ModMasters.Remove(item);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void DeleteSingleModuleByKey(ModMaster mod, AP5_NewContext _context)
        {
            try
            {
                List<ModMaster> result = (from t in _context.ModMasters
                                          where (t.CarType == mod.CarType)
                                            && (t.ModNo == mod.ModNo)
                                            && (t.Country == mod.Country)
                                          select t).ToList();
                _context.ModMasters.Remove(result[0]);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public List<ModMaster> GetModuleByOpSearch(ModMaster mod, AP5_NewContext _context)
        {
            try
            {
                int nowHour = DateTime.Now.Hour;
                DateTime nowDate = DateTime.Now;
                if (nowHour <= 3)
                {
                    nowDate = nowDate.AddDays(-1);
                }
                string OperationDate = nowDate.ToString("yyyyMMdd");

                List<ModMaster> resultList = (from t in _context.ModMasters
                                              where (t.UnboxDate == OperationDate)
                                                && (t.UnboxArea == mod.UnboxArea)
                                                && (t.PlantCode == mod.PlantCode || mod.PlantCode == null)
                                                && (t.DoneFlag == "0")
                                              orderby t.PlantCode ascending, t.ShiftType ascending, t.LineoffCount ascending
                                              select t).Take(2).ToList();
                return resultList;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void StartBtnModuleOp(ModMaster mod, AP5_NewContext _context)
        {
            try
            {
                int nowHour = DateTime.Now.Hour;
                DateTime nowDate = DateTime.Now;
                if (nowHour <= 3)
                {
                    nowDate = nowDate.AddDays(-1);
                }
                string OperationDate = nowDate.ToString("yyyyMMdd");

                ModMaster module = (from t in _context.ModMasters
                                    where (t.UnboxDate == OperationDate)
                                      && (t.UnboxArea == mod.UnboxArea)
                                      && (t.PlantCode == mod.PlantCode || mod.PlantCode == null)
                                      && (t.DoneFlag == "0")
                                    orderby t.PlantCode ascending, t.ShiftType ascending, t.LineoffCount ascending
                                    select t).Take(1).SingleOrDefault();

                module.StartTime = DateTime.Now;
                module.ModStatus = "開梱中";

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void EndBtnModuleOp(ModMaster mod, AP5_NewContext _context)
        {
            try
            {
                int nowHour = DateTime.Now.Hour;
                DateTime nowDate = DateTime.Now;
                if (nowHour <= 3)
                {
                    nowDate = nowDate.AddDays(-1);
                }
                string OperationDate = nowDate.ToString("yyyyMMdd");

                ModMaster module = (from t in _context.ModMasters
                                    where (t.UnboxDate == OperationDate)
                                      && (t.UnboxArea == mod.UnboxArea)
                                      && (t.PlantCode == mod.PlantCode || mod.PlantCode == null)
                                      && (t.DoneFlag == "0")
                                    orderby t.PlantCode ascending, t.ShiftType ascending, t.LineoffCount ascending
                                    select t).Take(1).SingleOrDefault();

                module.EndTime = DateTime.Now;
                TimeSpan timespan = (TimeSpan)(module.EndTime - module.StartTime);
                module.ProcessTime = (int)timespan.TotalMinutes;
                module.DoneFlag = "1";
                module.ModStatus = "開梱結束";

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public List<ModMaster> GetTVModuleData(ModMaster mod, AP5_NewContext _context)
        {
            try
            {
                int nowHour = DateTime.Now.Hour;
                DateTime nowDate = DateTime.Now;
                if (nowHour <= 3)
                {
                    nowDate = nowDate.AddDays(-1);
                }
                string OperationDate = nowDate.ToString("yyyyMMdd");
                List<ModMaster> gridList = (from t in _context.ModMasters
                                            where (t.UnboxDate == OperationDate)
                                              && (t.UnboxArea == mod.UnboxArea)
                                              && (t.PlantCode == mod.PlantCode)
                                              && (t.DoneFlag == "1")
                                            orderby t.PlantCode ascending, t.ShiftType ascending, t.LineoffCount descending
                                            select t).Take(1).ToList();
                List<ModMaster> prepareList = (from t in _context.ModMasters
                                               where (t.UnboxDate == OperationDate)
                                                 && (t.UnboxArea == mod.UnboxArea)
                                                 && (t.PlantCode == mod.PlantCode)
                                                 && (t.DoneFlag == "0")
                                               orderby t.PlantCode ascending, t.ShiftType ascending, t.LineoffCount ascending
                                               select t).Take(2).ToList();
                gridList.AddRange(prepareList);
                return gridList;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
