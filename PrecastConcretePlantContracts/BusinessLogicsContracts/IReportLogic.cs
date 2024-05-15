using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecastConcretePlantContracts.BusinessLogicsContracts
{
    public interface IReportLogic
    {
        List<ReportReinforcedComponentViewModel> GetReinforcedComponent();
        List<ReportWarehouseComponentViewModel> GetWarehouseComponent();
        List<ReportOrdersViewModel> GetOrders(ReportBindingModel model);
        List<ReportGeneralOrdersViewModel> GetGeneralOrders(ReportBindingModel model);
        void SaveComponentsToWordFile(ReportBindingModel model);
        void SaveWarehousesToWordFile(ReportBindingModel model);
        void SaveReinforcedComponentToExcelFile(ReportBindingModel model);
        void SaveWarehouseComponentToExcelFile(ReportBindingModel model);
        void SaveOrdersToPdfFile(ReportBindingModel model);
        void SaveGeneralOrdersToPdfFile(ReportBindingModel model);

    }
}
