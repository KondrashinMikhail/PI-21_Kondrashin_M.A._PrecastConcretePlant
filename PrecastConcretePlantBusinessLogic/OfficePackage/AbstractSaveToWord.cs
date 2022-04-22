using PrecastConcretePlantBusinessLogic.OfficePackage.HelperEnums;
using PrecastConcretePlantBusinessLogic.OfficePackage.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecastConcretePlantBusinessLogic.OfficePackage
{
    public abstract class AbstractSaveToWord
    {
        public void CreateDoc(WordInfo info)
        {
            CreateWord(info);
            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)> { (info.Title, new WordTextProperties { Bold = true, Size = "24", }) },
                TextProperties = new WordTextProperties
                {
                    Size = "24",
                    JustificationType = WordJustificationType.Center
                }
            });
            foreach (var reinforced in info.Reinforceds)
            {
                CreateParagraph(new WordParagraph
                {
                    Texts = new List<(string, WordTextProperties)> { (reinforced.ReinforcedName + " ", new WordTextProperties { Size = "24", Bold = true }),
                    (reinforced.Price.ToString(), new WordTextProperties { Size = "24" })},
                    TextProperties = new WordTextProperties
                    {
                        Size = "24", 
                        JustificationType = WordJustificationType.Both
                    }
                });
            }
            SaveWord(info);
        }
        public void CreateWarehouseDoc(WordInfo info) 
        {
            CreateWord(info);
            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)> { (info.Title, new WordTextProperties { Bold = true, Size = "24", }) },
                TextProperties = new WordTextProperties
                {
                    Size = "24",
                    JustificationType = WordJustificationType.Center
                }
            });
            CreateTable(new List<string>() { "Название", "ФИО ответственного", "Дата создания" });
            foreach (var warehouse in info.Warehouses)
            {
                AddRow(new List<string>() {
                    warehouse.WarehouseName,
                    warehouse.WarehouseManagerFullName,
                    warehouse.DateCreate.ToString()
                });
            }
            SaveWord(info);
        }
        protected abstract void CreateWord(WordInfo info);
        protected abstract void CreateParagraph(WordParagraph paragraph);
        protected abstract void CreateTable(List<string> tableHeaderInfo);
        protected abstract void AddRow(List<string> tableRowInfo);
        protected abstract void SaveWord(WordInfo info);
    }
}
