using Newtonsoft.Json;

namespace RealTime
{
    public class RealtimeConfig
    {
        /// <summary>
        /// Intervalle de mise à jour en millisecondes (par défaut: 1000ms = 1 seconde)
        /// </summary>
        [JsonProperty("update_interval_ms")]
        public int UpdateIntervalMs { get; set; } = 1000;

        /// <summary>
        /// Activer le plugin automatiquement au démarrage du serveur
        /// </summary>
        [JsonProperty("enabled_on_startup")]
        public bool EnabledOnStartup { get; set; } = true;

        /// <summary>
        /// Activer le mode debug pour afficher les informations de synchronisation
        /// </summary>
        [JsonProperty("debug_mode")]
        public bool DebugMode { get; set; } = false;

        /// <summary>
        /// Heure de début du jour dans Terraria (par défaut: 4.5 = 4h30)
        /// </summary>
        [JsonProperty("terraria_day_start")]
        public double TerrariaDayStart { get; set; } = 4.5;

        /// <summary>
        /// Heure de début de la nuit dans Terraria (par défaut: 19.5 = 19h30)
        /// </summary>
        [JsonProperty("terraria_night_start")]
        public double TerrariaNightStart { get; set; } = 19.5;

        /// <summary>
        /// Durée du jour en secondes de jeu Terraria (par défaut: 54000 = 15 heures)
        /// </summary>
        [JsonProperty("terraria_day_duration")]
        public double TerrariaDayDuration { get; set; } = 54000.0;

        /// <summary>
        /// Durée de la nuit en secondes de jeu Terraria (par défaut: 32400 = 9 heures)
        /// </summary>
        [JsonProperty("terraria_night_duration")]
        public double TerrariaNightDuration { get; set; } = 32400.0;
    }
}
