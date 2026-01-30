using System;
using System.IO;
using Newtonsoft.Json;
using TShockAPI;

namespace RealTime
{
    public class ConfigManager
    {
        private static readonly string ConfigPath = Path.Combine(TShock.SavePath, "RealTimeConfig.json");

        public static RealtimeConfig LoadConfig()
        {
            try
            {
                if (!File.Exists(ConfigPath))
                {
                    var defaultConfig = new RealtimeConfig();
                    SaveConfig(defaultConfig);
                    TShock.Log.ConsoleInfo("[RealTime] Configuration file created at: " + ConfigPath);
                    return defaultConfig;
                }

                string json = File.ReadAllText(ConfigPath);
                var config = JsonConvert.DeserializeObject<RealtimeConfig>(json);
                
                if (config == null)
                {
                    TShock.Log.ConsoleError("[RealTime] Failed to deserialize config. Using defaults.");
                    return new RealtimeConfig();
                }

                TShock.Log.ConsoleInfo("[RealTime] Configuration loaded successfully.");
                return config;
            }
            catch (Exception ex)
            {
                TShock.Log.ConsoleError($"[RealTime] Error loading config: {ex.Message}");
                return new RealtimeConfig();
            }
        }

        public static void SaveConfig(RealtimeConfig config)
        {
            try
            {
                string json = JsonConvert.SerializeObject(config, Formatting.Indented);
                File.WriteAllText(ConfigPath, json);
            }
            catch (Exception ex)
            {
                TShock.Log.ConsoleError($"[RealTime] Error saving config: {ex.Message}");
            }
        }

        public static string GetConfigPath()
        {
            return ConfigPath;
        }
    }
}
