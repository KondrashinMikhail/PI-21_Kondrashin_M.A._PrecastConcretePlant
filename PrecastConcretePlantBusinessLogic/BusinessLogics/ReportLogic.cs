using PrecastConcretePlantBusinessLogic.OfficePackage;
using PrecastConcretePlantBusinessLogic.OfficePackage.HelperModels;
using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.BusinessLogicsContracts;
using PrecastConcretePlantContracts.StoragesContracts;
using PrecastConcretePlantContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecastConcretePlantBusinessLogic.BusinessLogics
{
        public class ReportLogic : IReportLogic
        {
            private readonly IComponentStorage _componentStorage;
            private readonly IReinforcedStorage _reinforcedStorage;
            private readonly IOrderStorage _orderStorage;
            private readonly AbstractSaveToExcel _saveToExcel;
            private readonly AbstractSaveToWord _saveToWord;
            private readonly AbstractSaveToPdf _saveToPdf;
            public ReportLogic(IReinforcedStorage reinforcedStorage, IComponentStorage componentStorage, IOrderStorage orderStorage,
            AbstractSaveToExcel saveToExcel, AbstractSaveToWord saveToWord, AbstractSaveToPdf saveToPdf)
            {
                _reinforcedStorage = reinforcedStorage;
                _componentStorage = componentStorage;
                _orderStorage = orderStorage;
                _saveToExcel = saveToExcel;
                _saveToWord = saveToWord;
                _saveToPdf = saveToPdf;
            }
            public List<ReportReinforcedComponentViewModel> GetReinforcedComponent()
            {
                var components = _componentStorage.GetFullList();
                var reinforceds = _reinforcedStorage.GetFullList();
                var list = new List<ReportReinforcedComponentViewModel>();
                foreach (var component in components)
                {
                    var record = new ReportReinforcedComponentViewModel
                    {
                        ComponentName = component.ComponentName,
                        Reinforceds = new List<Tuple<string, int>>(),
                        TotalCount = 0
                    };
                    foreach (var reinforced in reinforceds)
                    {
                        if (reinforced.ReinforcedComponents.ContainsKey(component.Id))
                        {
                            record.Reinforceds.Add(new Tuple<string, int>(reinforced.ReinforcedName,
                           reinforced.ReinforcedComponents[component.Id].Item2));
                            record.TotalCount +=
                           reinforced.ReinforcedComponents[component.Id].Item2;
                        }
                    }
                    list.Add(record);
                }
                return list;
            }
            public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
            {
                return _orderStorage.GetFilteredList(new OrderBindingModel
                {
                    DateFrom = model.DateFrom,
                    DateTo = model.DateTo
                })
                .Select(x => new ReportOrdersViewModel
                {
                    DateCreate = x.DateCreate,
                    ReinforcedName = x.ReinforcedName,
                    Count = x.Count,
                    Sum = x.Sum,
                    Status = x.Status
                })
               .ToList();
            }
            public void SaveComponentsToWordFile(ReportBindingModel model)
            {
                _saveToWord.CreateDoc(new WordInfo
                {
                    FileName = model.FileName,
                    Title = "Список компонент",
                    Components = _componentStorage.GetFullList()
                });
            }
            public void SaveReinforcedComponentToExcelFile(ReportBindingModel model)
            {
                _saveToExcel.CreateReport(new ExcelInfo
                {
                    FileName = model.FileName,
                    Title = "Список компонент",
                    ReinforcedComponents = GetReinforcedComponent()
                });
            }
            public void SaveOrdersToPdfFile(ReportBindingModel model)
            {
                _saveToPdf.CreateDoc(new PdfInfo
                {
                    FileName = model.FileName,
                    Title = "Список заказов",
                    DateFrom = model.DateFrom.Value,
                    DateTo = model.DateTo.Value,
                    Orders = GetOrders(model)
                });
            }
        }
    }
