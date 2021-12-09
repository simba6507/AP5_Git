using AP5_New.Models;
using AP5_New.Services.IServices;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Npoi.Mapper;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace AP5_New.Services.ServiceImplement
{
    public class CodeService : ICodeService
    {
        ModuleService moduleService = new ModuleService();
        ContainerService containerService = new ContainerService();

        public List<SelectListItem> GetModuleCountry(AP5_NewContext _context)
        {
            try
            {
                List<SelectListItem> resultList = new List<SelectListItem>();
                List<string> modList = _context.ModMasters.Select(x => x.Country).Distinct().ToList();

                foreach (var item in modList)
                {
                    resultList.Add(new SelectListItem { Text = item, Value = item });
                }

                return resultList;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public List<SelectListItem> GetModulePlantCode(AP5_NewContext _context)
        {

            try
            {
                List<SelectListItem> resultList = new List<SelectListItem>();
                List<string> modList = _context.ModMasters.Select(x => x.PlantCode).Distinct().ToList();
                foreach (var item in modList)
                {
                    resultList.Add(new SelectListItem { Text = item, Value = item });
                }

                return resultList;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public List<SelectListItem> GetModuleUnboxArea(AP5_NewContext _context)
        {

            try
            {
                List<SelectListItem> resultList = new List<SelectListItem>();
                List<int> modList = _context.ModMasters.Select(x => x.UnboxArea).Distinct().ToList();
                foreach (var item in modList)
                {
                    resultList.Add(new SelectListItem { Text = item.ToString(), Value = item.ToString() });
                }

                return resultList;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public string importExcel(string fileName,string fileSubstring,AP5_NewContext _context)
        {

            try
            {
                var mapper = new Mapper(fileName);
                var numberOfSheets = mapper.Workbook.NumberOfSheets;
                string resultString = string.Empty;

                switch (fileSubstring)
                {
                    case "開梱計畫":
                        List<ModMaster> modList = new List<ModMaster>();
                        for (var i = 0; i < numberOfSheets; i++)
                        {
                            var rowInfos = mapper.Take<ModMaster>(i).ToList();

                            foreach (var sheetInfo in mapper.Objects)
                            {
                                foreach (var rowInfo in sheetInfo.Value)
                                {
                                    var rowIndex = rowInfo.Key;
                                    var rowData = rowInfo.Value as ModMaster;
                                    if (rowData.PlantCode.Length > 4 || rowData.PlantCode == null || rowData.PlantCode.Trim() == "")
                                    {
                                        resultString += "第" + (rowIndex + 1) + "列: 廠別長度大於4或有空值。";
                                    }
                                }
                            }

                            foreach (var rowInfo in rowInfos)
                            {
                                if (string.IsNullOrWhiteSpace(rowInfo.ErrorMessage) == false)
                                {
                                    resultString += "第"+(rowInfo.RowNumber+1)+"列第"+rowInfo.ErrorColumnIndex + "欄: ";
                                    resultString += rowInfo.ErrorMessage + "。 ";
                                }
                            }
                        }
                        if (resultString != string.Empty)
                        {
                            return resultString;
                        }
                        foreach (var sheetInfo in mapper.Objects)
                        {
                            var sheetName = sheetInfo.Key;
                            foreach (var rowInfo in sheetInfo.Value)
                            {
                                var rowIndex = rowInfo.Key;
                                var rowData = rowInfo.Value as ModMaster;
                                moduleService.InsertUpdateToModMaster(rowData, _context);
                            }
                        }
                        resultString += "上傳完成。";
                        break;

                    case "下櫃計畫":
                        List<ContainerMaster> containerList = new List<ContainerMaster>();
                        for (var i = 0; i < numberOfSheets; i++)
                        {
                            var rowInfos = mapper.Take<ContainerMaster>(i).ToList();
                            foreach (var rowInfo in rowInfos)
                            {
                                if (string.IsNullOrWhiteSpace(rowInfo.ErrorMessage) == false)
                                {
                                    resultString += "第" + (rowInfo.RowNumber + 1) + "列第" + rowInfo.ErrorColumnIndex + "欄: ";
                                    resultString += rowInfo.ErrorMessage + "。 ";
                                }
                            }
                        }
                        if (resultString != string.Empty)
                        {
                            return resultString;
                        }
                        foreach (var sheetInfo in mapper.Objects)
                        {
                            var sheetName = sheetInfo.Key;
                            foreach (var rowInfo in sheetInfo.Value)
                            {
                                var rowIndex = rowInfo.Key;
                                var rowData = rowInfo.Value as ContainerMaster;
                                containerService.InsertUpdateToContainerMaster(rowData, _context);
                            }
                        }
                        resultString += "上傳完成。";
                        break;

                    default:
                        break;
                }

                return resultString;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string exportExcel<T>(string savePath, string fileSubstring,List<T> sourceList, AP5_NewContext _context)
        {
            string resultString = string.Empty;
            try
            {
                var mapper = new Mapper();
                switch (fileSubstring)
                {
                    case "開梱計畫":
                        mapper.Map<ModMaster>("廠別", s => s.PlantCode)
                            .Map<ModMaster>("開梱日期", s => s.UnboxDate)
                            .Map<ModMaster>("直別", s => s.ShiftType)
                            .Map<ModMaster>("車種", s => s.CarType)
                            .Map<ModMaster>("國別", s => s.Country)
                            .Map<ModMaster>("MOD_NO", s => s.ModNo)
                            .Map<ModMaster>("開梱台編號", s => s.UnboxArea)
                            .Map<ModMaster>("開梱台數", s => s.LineoffCount)
                            .Map<ModMaster>("註記", s => s.Mark)
                            .Map<ModMaster>("理論作業時間", s => s.LogicalTime)
                            .Map<ModMaster>("開始時間", s => s.StartTime).Format<ModMaster>("yyyy/MM/dd HH:mm:ss", s => s.StartTime)
                            .Map<ModMaster>("結束時間", s => s.EndTime).Format<ModMaster>("yyyy/MM/dd HH:mm:ss", s => s.EndTime)
                            .Map<ModMaster>("相隔時間", s => s.ProcessTime)
                            .Map<ModMaster>("完成標記", s => s.DoneFlag)
                            .Map<ModMaster>("MOD狀態", s => s.ModStatus);
                        break;

                    case "下櫃計畫":
                        mapper.Map<ContainerMaster>("廠別", s => s.PlantCode)
                            .Map<ContainerMaster>("下櫃日期", s => s.UnboxDate)
                            .Map<ContainerMaster>("直別", s => s.ShiftType)
                            .Map<ContainerMaster>("貨櫃連番", s => s.ContainerRenban)
                            .Map<ContainerMaster>("國別", s => s.Country)
                            .Map<ContainerMaster>("貨櫃編號", s => s.ContainerNo)
                            .Map<ContainerMaster>("碼頭代號", s => s.DockNo)
                            .Map<ContainerMaster>("下櫃台數", s => s.LineoffCount)
                            .Map<ContainerMaster>("備註", s => s.Mark)
                            .Map<ContainerMaster>("理論作業時間", s => s.LogicalTime)
                            .Map<ContainerMaster>("開始時間", s => s.StartTime).Format<ContainerMaster>("yyyy/MM/dd HH:mm:ss", s => s.StartTime)
                            .Map<ContainerMaster>("結束時間", s => s.EndTime).Format<ContainerMaster>("yyyy/MM/dd HH:mm:ss", s => s.EndTime)
                            .Map<ContainerMaster>("相隔時間", s => s.ProcessTime)
                            .Map<ContainerMaster>("完成標記", s => s.DoneFlag)
                            .Map<ContainerMaster>("下櫃狀態", s => s.ContainerStatus);
                        break;

                    default:
                        break;
                }
                string fullFileName = savePath + fileSubstring + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
                string fileName = fileSubstring + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
                mapper.Save(fullFileName, sourceList, "sheet1", overwrite: true, xlsx: true);
                return fileName;
            }
            catch (Exception)
            {
                throw;
            }
            

        }

        public List<SelectListItem> GetContainerPlantCode(AP5_NewContext _context)
        {

            try
            {
                List<SelectListItem> resultList = new List<SelectListItem>();
                List<string> modList = _context.ContainerMasters.Select(x => x.PlantCode).Distinct().ToList();
                foreach (var item in modList)
                {
                    resultList.Add(new SelectListItem { Text = item, Value = item });
                }

                return resultList;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public List<SelectListItem> GetContainerCountry(AP5_NewContext _context)
        {

            try
            {
                List<SelectListItem> resultList = new List<SelectListItem>();
                List<string> modList = _context.ContainerMasters.Select(x => x.Country).Distinct().ToList();
                foreach (var item in modList)
                {
                    resultList.Add(new SelectListItem { Text = item, Value = item });
                }

                return resultList;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public List<SelectListItem> GetContainerDockNo(AP5_NewContext _context)
        {

            try
            {
                List<SelectListItem> resultList = new List<SelectListItem>();
                List<int> modList = _context.ContainerMasters.Select(x => x.DockNo).Distinct().ToList();
                foreach (var item in modList)
                {
                    resultList.Add(new SelectListItem { Text = item.ToString(), Value = item.ToString() });
                }

                return resultList;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public string GetCLLineOffCount(CL_COUNTERDBContext _context)
        {

            try
            {
                string lineOffCount = (from t in _context.TNumberOfLineOffs
                                       orderby t.UpdateDate descending
                                       select t.NumberOfLineOff - t.LoAdjustment).FirstOrDefault().ToString();
                return lineOffCount;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public string GetKNLineOffCount(KN_COUNTERDBContext _context)
        {

            try
            {
                string lineOffCount = (from t in _context.TNumberOfLineOffs
                                       orderby t.UpdateDate descending
                                       select t.NumberOfLineOff - t.LoAdjustment).FirstOrDefault().ToString();
                return lineOffCount;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<SelectListItem> GetPlanLineOffPlantCode(AP5_NewContext _context)
        {
            try
            {
                List<SelectListItem> resultList = new List<SelectListItem>();
                List<string> modList = _context.PlanLineoffs.Select(x => x.PlantCode).Distinct().ToList();
                foreach (var item in modList)
                {
                    resultList.Add(new SelectListItem { Text = item, Value = item });
                }

                return resultList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<SelectListItem> GetPlanLineOffShiftType(AP5_NewContext _context)
        {
            try
            {
                List<SelectListItem> resultList = new List<SelectListItem>();
                List<int?> modList = _context.PlanLineoffs.Select(x => x.ShiftType).Distinct().ToList();
                foreach (var item in modList)
                {
                    resultList.Add(new SelectListItem { Text = item.ToString(), Value = item.ToString() });
                }

                return resultList;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
