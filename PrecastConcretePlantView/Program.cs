using PrecastConcretePlantBusinessLogic.BusinessLogics;
using PrecastConcretePlantBusinessLogic.OfficePackage;
using PrecastConcretePlantBusinessLogic.OfficePackage.Implements;
using PrecastConcretePlantContracts.BusinessLogicsContracts;
using PrecastConcretePlantContracts.StoragesContracts;
using PrecastConcretePlantDatabaseImplement.Implements;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace PrecastConcretePlantView
{
    static class Program
    {
        private static IUnityContainer container = null;
        public static IUnityContainer Container
        {
            get
            {
                if (container == null) container = BuildUnityContainer();
                return container;
            }
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Container.Resolve<FormMain>());
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IComponentStorage, ComponentStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOrderStorage, OrderStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IReinforcedStorage, ReinforcedStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IWarehouseStorage, WarehouseStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IClientStorage, ClientStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IComponentLogic, ComponentLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOrderLogic, OrderLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IReinforcedLogic, ReinforcedLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IWarehouseLogic, WarehouseLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IReportLogic, ReportLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IClientLogic, ClientLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<AbstractSaveToExcel, SaveToExcel>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<AbstractSaveToWord, SaveToWord>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<AbstractSaveToPdf, SaveToPdf>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}