using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RestApiTester.Models
{
    public class AppConfig
    {
        private static AppConfig _singleton = null;
        private AppConfig()
        {
        }
        public static AppConfig GetInstance()
        {
            if(_singleton == null)
            {
                _singleton = new AppConfig();
                _singleton.Load();
            }
            return _singleton;
        }
        private string Path
        {
            get
            {
                return System.IO.Path.ChangeExtension(
                    System.Reflection.Assembly.GetExecutingAssembly().Location,
                    ".conf");
            }
        }
        private void Load()
        {
            var doc = XDocument.Load(this.Path);
            this.Imports = doc.Element("Configurations").Element("Imports").Elements("Import").Select(x => x.Value).ToArray();

            var assemblies = doc.Element("Configurations").Element("References").Elements("Reference")
                .Select(x => x.Value).ToArray();

            this.Assemblies = AssemblyLoadContext.Default.Assemblies
                .Where(x => assemblies.Contains(x.GetName().Name)).ToArray();
        }
        public Assembly[] Assemblies
        {
            get;
            private set;
        }
        public string[] Imports
        {
            get;
            private set;
        }
    }
}
