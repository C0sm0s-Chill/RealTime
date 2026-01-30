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
        private const double TimeOffset = 4.50;
        private const double DayNightTransition = 15.00;
        private const int UpdateIntervalMs = 1000;

        public RealTime(Main game) : base(game)
        {
        }

        public override void Initialize()
        {
            Commands.ChatCommands.Add(new Command("tshock.RealTime", RealTimeOnOff, "rt", "realtime"));
            StartRealTimeTimer();
        }

        #region Plugin Info
        public override Version Version => new Version("1.1");
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

                _realTimeTimer = new System.Timers.Timer(UpdateIntervalMs);
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
            time -= (decimal)TimeOffset;
            
            if (time < 0.00m)
                time += 24.00m;
            
            bool isDaytime = time < (decimal)DayNightTransition;
            double gameTime = isDaytime 
                ? (double)(time * 3600.0m) 
                : (double)((time - (decimal)DayNightTransition) * 3600.0m);
            
            TSPlayer.Server.SetTime(isDaytime, gameTime);
        }

        private void RealTimeOnOff(CommandArgs args)
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
