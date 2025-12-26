using System;
using System.Windows.Input;
using Newtonsoft.Json;
using _4RTools.Utils;
using System.Threading;
using System.Drawing;

namespace _4RTools.Model
{
    public class MouseBoost : Action
    {
        public static string ACTION_NAME_MOUSEBOOST = "MouseBoost";
        private _4RThread thread;
        public bool isEnabled { get; set; } = false;
        public int moveSpeed { get; set; } = 5;
        public Key toggleKey { get; set; } = Key.None;

        public string GetActionName()
        {
            return ACTION_NAME_MOUSEBOOST;
        }

        public string GetConfiguration()
        {
            return JsonConvert.SerializeObject(this);
        }

        public void Start()
        {
            Client roClient = ClientSingleton.GetClient();
            if (roClient != null && isEnabled)
            {
                this.thread = new _4RThread(_ => MouseBoostThreadExecution(roClient));
                _4RThread.Start(this.thread);
            }
        }

        private int MouseBoostThreadExecution(Client roClient)
        {
            try
            {
                if (this.toggleKey != Key.None && Keyboard.IsKeyDown(this.toggleKey))
                {
                    while (Keyboard.IsKeyDown(this.toggleKey))
                    {
                        Point currentPos = System.Windows.Forms.Cursor.Position;
                        
                        // Send WM_MOUSEMOVE message to the game client
                        // lParam format: low-order word is x, high-order word is y
                        // Ensure coordinates fit within 16-bit signed integer range
                        int x = Math.Max(0, Math.Min(currentPos.X, 0x7FFF));
                        int y = Math.Max(0, Math.Min(currentPos.Y, 0x7FFF));
                        int lParam = (y << 16) | (x & 0xFFFF);
                        
                        Interop.PostMessage(roClient.process.MainWindowHandle, Constants.WM_MOUSEMOVE, 0, lParam);
                        
                        Thread.Sleep(this.moveSpeed);
                    }
                }
            }
            catch (Exception)
            {
                // Handle any exceptions to prevent thread crashes
            }
            return 0;
        }

        public void Stop()
        {
            if (this.thread != null)
            {
                _4RThread.Stop(this.thread);
            }
        }
    }
}
