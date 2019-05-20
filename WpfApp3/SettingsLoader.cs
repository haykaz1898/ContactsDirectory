using System.IO;
using Newtonsoft.Json;


namespace WpfApp3
{
    public class SettingsLoader
    {
        private ProgramSettings _programSettings;
        private static SettingsLoader _settingsLoader;

        private SettingsLoader()
        {
            _programSettings = JsonConvert.DeserializeObject<ProgramSettings>(File.ReadAllText(@".\settings.json"));
        }

        public static SettingsLoader Load()
        {
            if (_settingsLoader == null)
            {
                _settingsLoader = new SettingsLoader();
            }
            return _settingsLoader;
        }

        public void SaveChanges(ProgramSettings changedSettings)
        {
            string s = JsonConvert.SerializeObject(changedSettings);
            StreamWriter sw = new StreamWriter("settings.json");
            sw.Write(s);
            sw.Close();
        }

        public ProgramSettings GetSettings()
        {
            return _programSettings;
        }
    }
}
