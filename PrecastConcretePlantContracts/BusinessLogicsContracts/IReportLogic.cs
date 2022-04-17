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
        List<ReportOrdersViewModel> GetOrders(ReportBindingModel model);
        void SaveComponentsToWordFile(ReportBindingModel model);
        void SaveReinforcedComponentToExcelFile(ReportBindingModel model);
        void SaveOrdersToPdfFile(ReportBindingModel model);

    }
}
