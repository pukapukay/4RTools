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
            if (this.toggleKey != Key.None && Keyboard.IsKeyDown(this.toggleKey))
            {
                Point currentPos = System.Windows.Forms.Cursor.Position;
                
                // Send WM_MOUSEMOVE message to the game client
                // lParam format: low-order word is x, high-order word is y
                int lParam = (currentPos.Y << 16) | (currentPos.X & 0xFFFF);
                
                Interop.PostMessage(roClient.process.MainWindowHandle, Constants.WM_MOUSEMOVE, 0, lParam);
                
                Thread.Sleep(this.moveSpeed);
            }
            return 0;
        }

        public void Stop()
        {
            _4RThread.Stop(this.thread);
        }
    }
}
