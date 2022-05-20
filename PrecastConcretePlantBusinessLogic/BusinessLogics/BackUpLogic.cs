using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.BusinessLogicsContracts;
using PrecastConcretePlantContracts.StoragesContracts;
using System.IO.Compression;
using System.Reflection;
using System.Xml.Serialization;

namespace PrecastConcretePlantBusinessLogic.BusinessLogics
{
    public class BackUpLogic : IBackUpLogic
    {
        private readonly IBackUpInfo _backUpInfo;
        public BackUpLogic(IBackUpInfo backUpInfo) => _backUpInfo = backUpInfo;
        public void CreateBackUp(BackUpSaveBindingModel model)
        {
            if (_backUpInfo == null) return;
            try
            {
                var dirInfo = new DirectoryInfo(model.FolderName);
                if (dirInfo.Exists) foreach (FileInfo file in dirInfo.GetFiles()) file.Delete();
                string fileName = $"{model.FolderName}.zip";
                if (File.Exists(fileName)) File.Delete(fileName);
                Assembly assem = _backUpInfo.GetAssembly();
                var dbsets = _backUpInfo.GetFullList();
                MethodInfo method = GetType().GetTypeInfo().GetDeclaredMethod("SaveToFile");
                foreach (var set in dbsets)
                {
                    var elem = assem.CreateInstance(set.PropertyType.GenericTypeArguments[0].FullName);
                    MethodInfo generic = method.MakeGenericMethod(elem.GetType());
                    generic.Invoke(this, new object[] { model.FolderName });
                }
                ZipFile.CreateFromDirectory(model.FolderName, fileName);
                dirInfo.Delete(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void SaveToFile<T>(string folderName) where T : class, new()
        {
            var records = _backUpInfo.GetList<T>();
            var obj = new T();
            var xml = new XmlSerializer(typeof(List<T>));
            using var fs = new FileStream(string.Format("{0}/{1}.xml", folderName, obj.GetType().Name), FileMode.OpenOrCreate);
            xml.Serialize(fs, records);
        }
    }
}
