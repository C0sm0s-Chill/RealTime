using System;
using System.Timers;
using Terraria;
using TerrariaApi.Server;
using TShockAPI;

namespace RealTime
{
    [ApiVersion(2, 1)]
    public class RealTime : TerrariaPlugin
    {
        private System.Timers.Timer? _realTimeTimer;
        private readonly object _timerLock = new object();
        private RealtimeConfig _config;

        public RealTime(Main game) : base(game)
        {
            _config = new RealtimeConfig();
        }

        public override void Initialize()
        {
            _config = ConfigManager.LoadConfig();
            Commands.ChatCommands.Add(new Command("tshock.RealTime", RealTimeCommand, "rt", "realtime"));
            
            if (_config.EnabledOnStartup)
            {
                StartRealTimeTimer();
            }
        }

        #region Plugin Info
        public override Version Version => new Version("1.2");
        public override string Name => "RealTime";
        public override string Author => "QviNSteN / C0sm0s";
        public override string Description => "Synchronizes Terraria server time with real-world time";
        #endregion Plugin Info

        private void StartRealTimeTimer()
        {
            lock (_timerLock)
            {
                if (_realTimeTimer != null)
                    return;

                _realTimeTimer = new System.Timers.Timer(_config.UpdateIntervalMs);
                _realTimeTimer.Elapsed += OnTimerElapsed;
                _realTimeTimer.AutoReset = true;
                _realTimeTimer.Start();
            }
        }

        private void StopRealTimeTimer()
        {
            lock (_timerLock)
            {
                if (_realTimeTimer == null)
                    return;

                _realTimeTimer.Stop();
                _realTimeTimer.Elapsed -= OnTimerElapsed;
                _realTimeTimer.Dispose();
                _realTimeTimer = null;
            }
        }

        private void OnTimerElapsed(object? sender, ElapsedEventArgs e)
        {
            try
            {
                SyncTimeWithRealWorld();
            }
            catch (Exception ex)
            {
                TShock.Log.Error($"[RealTime] Error syncing time: {ex.Message}");
            }
        }

        private void SyncTimeWithRealWorld()
        {
            var currentTime = DateTimeOffset.Now.ToLocalTime();
            var hours = currentTime.Hour;
            var minutes = currentTime.Minute;
            
            var time = hours + minutes / 60.0m;
            time -= (decimal)_config.TimeOffset;
            
            if (time < 0.00m)
                time += 24.00m;
            
            bool isDaytime = time < (decimal)_config.DayNightTransition;
            double gameTime = isDaytime 
                ? (double)(time * 3600.0m) 
                : (double)((time - (decimal)_config.DayNightTransition) * 3600.0m);
            
            TSPlayer.Server.SetTime(isDaytime, gameTime);
        }

        private void RealTimeCommand(CommandArgs args)
        {
            if (args.Parameters.Count > 0 && args.Parameters[0].ToLower() == "reload")
            {
                ReloadConfig(args);
                return;
            }

            ToggleRealTime(args);
        }

        private void ToggleRealTime(CommandArgs args)
        {
            lock (_timerLock)
            {
                bool isEnabled = _realTimeTimer != null;
                
                if (isEnabled)
                {
                    StopRealTimeTimer();
                    TSPlayer.Server.SetTime(true, Main.time);
                    args.Player.SendSuccessMessage("[RealTime] Plugin disabled.");
                }
                else
                {
                    StartRealTimeTimer();
                    args.Player.SendSuccessMessage("[RealTime] Plugin enabled.");
                }
            }
        }

        private void ReloadConfig(CommandArgs args)
        {
            try
            {
                bool wasEnabled = false;
                lock (_timerLock)
                {
                    wasEnabled = _realTimeTimer != null;
                    if (wasEnabled)
                    {
                        StopRealTimeTimer();
                    }
                }

                _config = ConfigManager.LoadConfig();
                args.Player.SendSuccessMessage($"[RealTime] Configuration reloaded from: {ConfigManager.GetConfigPath()}");
                args.Player.SendInfoMessage($"TimeOffset: {_config.TimeOffset}, DayNightTransition: {_config.DayNightTransition}, UpdateInterval: {_config.UpdateIntervalMs}ms");

                if (wasEnabled)
                {
                    StartRealTimeTimer();
                    args.Player.SendInfoMessage("[RealTime] Timer restarted with new configuration.");
                }
            }
            catch (Exception ex)
            {
                args.Player.SendErrorMessage($"[RealTime] Error reloading config: {ex.Message}");
                TShock.Log.Error($"[RealTime] Error reloading config: {ex}");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                StopRealTimeTimer();
            }
            base.Dispose(disposing);
        }
    }
}
