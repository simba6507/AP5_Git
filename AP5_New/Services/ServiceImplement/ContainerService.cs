using AP5_New.Models;
using AP5_New.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AP5_New.Services.ServiceImplement
{
    public class ContainerService : IContainerService
    {
        public void DeletefromContainerMaster(List<ContainerMaster> deleteList, AP5_NewContext _context)
        {
            try
            {
                foreach (var item in deleteList)
                {
                    _context.ContainerMasters.Remove(item);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public List<ContainerMaster> GetContainerByCondition(ContainerMaster container, AP5_NewContext _context)
        {
            try
            {
                var resultList = (from t in _context.ContainerMasters
                                  where (t.UnboxDate == container.UnboxDate || container.UnboxDate == null)
                                    && (t.DockNo == container.DockNo || container.DockNo == 0)
                                    && (t.PlantCode == container.PlantCode || container.PlantCode == null)
                                    && (t.Country == container.Country || container.Country == null)
                                  orderby t.UnboxDate descending, t.PlantCode ascending, t.ShiftType ascending, t.LineoffCount ascending
                                  select t);
                var test = resultList.ToList();
                return resultList.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void DeleteSingleContainerByKey(ContainerMaster container, AP5_NewContext _context)
        {
            try
            {
                List<ContainerMaster> result = (from t in _context.ContainerMasters
                                                where (t.ContainerNo == container.ContainerNo)
                                                  && (t.ContainerRenban == container.ContainerRenban)
                                                  && (t.Country == container.Country)
                                                select t).ToList();
                _context.ContainerMasters.Remove(result[0]);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void InsertUpdateToContainerMaster(ContainerMaster container, AP5_NewContext _context)
        {
            try
            {
                ContainerMaster existContainer = (from t in _context.ContainerMasters
                                                  where (t.ContainerRenban == container.ContainerRenban)
                                                    && (t.Country == container.Country)
                                                    && (t.ContainerNo == container.ContainerNo)
                                                  select t).FirstOrDefault();
                if (existContainer != null)
                {
                    existContainer.PlantCode = container.PlantCode;
                    existContainer.UnboxDate = container.UnboxDate;
                    existContainer.ShiftType = container.ShiftType;
                    existContainer.DockNo = container.DockNo;
                    existContainer.LineoffCount = container.LineoffCount;
                    existContainer.Mark = container.Mark;
                    existContainer.LogicalTime = container.LogicalTime;
                    _context.SaveChanges();
                }
                else
                {
                    container.ContainerStatus = "未下櫃";
                    container.DoneFlag = "0";
                    _context.ContainerMasters.Add(container);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public List<ContainerMaster> GetContainerByOpSearch(ContainerMaster container, AP5_NewContext _context)
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

                List<ContainerMaster> resultList = (from t in _context.ContainerMasters
                                                    where (t.UnboxDate == OperationDate)
                                                      && (t.DockNo == container.DockNo)
                                                      && (t.PlantCode == container.PlantCode || container.PlantCode == null)
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

        public void StartBtnContainerOp(ContainerMaster container, AP5_NewContext _context)
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

                ContainerMaster target_container = (from t in _context.ContainerMasters
                                                    where (t.UnboxDate == OperationDate)
                                                      && (t.DockNo == container.DockNo)
                                                      && (t.PlantCode == container.PlantCode || container.PlantCode == null)
                                                      && (t.DoneFlag == "0")
                                                    orderby t.PlantCode ascending, t.ShiftType ascending, t.LineoffCount ascending
                                                    select t).Take(1).SingleOrDefault();

                target_container.StartTime = DateTime.Now;
                target_container.ContainerStatus = "下櫃中";

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void EndBtnContainerOp(ContainerMaster container, AP5_NewContext _context)
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

                ContainerMaster target_container = (from t in _context.ContainerMasters
                                                    where (t.UnboxDate == OperationDate)
                                                      && (t.DockNo == container.DockNo)
                                                      && (t.PlantCode == container.PlantCode || container.PlantCode == null)
                                                      && (t.DoneFlag == "0")
                                                    orderby t.PlantCode ascending, t.ShiftType ascending, t.LineoffCount ascending
                                                    select t).Take(1).SingleOrDefault();

                target_container.EndTime = DateTime.Now;
                TimeSpan timespan = (TimeSpan)(target_container.EndTime - target_container.StartTime);
                target_container.ProcessTime = (int)timespan.TotalMinutes;
                target_container.DoneFlag = "1";
                target_container.ContainerStatus = "下櫃結束";

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public List<ContainerMaster> GetTVContainerData(ContainerMaster container, AP5_NewContext _context)
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
                List<ContainerMaster> gridList = (from t in _context.ContainerMasters
                                                  where (t.UnboxDate == OperationDate)
                                                    && (t.DockNo == container.DockNo)
                                                    && (t.PlantCode == container.PlantCode)
                                                    && (t.DoneFlag == "1")
                                                  orderby t.PlantCode ascending, t.ShiftType ascending, t.LineoffCount descending
                                                  select t).Take(1).ToList();
                List<ContainerMaster> prepareList = (from t in _context.ContainerMasters
                                                     where (t.UnboxDate == OperationDate)
                                                 && (t.DockNo == container.DockNo)
                                                 && (t.PlantCode == container.PlantCode)
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
