using Q42.HueApi;
using Q42.HueApi.Interfaces;
using Q42.HueApi.Models.Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Q42.HueApi.ColorConverters.OriginalWithModel;

namespace ColourLibrary
{
    public class ShowColourHue : IShowColour
    {
        LocatedBridge bridge = null;
        ILocalHueClient client;
        string appKey;

        const string APP_NAME = "TableLights";
        const string DEVICE_NAME = "RPi";


        public bool Connected
        {
            get { return bridge != null; }
        }

        public ShowColourHue()
        {
        }


        public int Count
        {
            get
            {
                if (! Connected)
                {
                    return 0;
                }
                throw new NotImplementedException();
            }
        }

        private HueColour defaultColour = HueColour.White;
        public HueColour DefaultColour
        {
            get
            {
                return defaultColour;
            }

            set
            {
                defaultColour = value;
            }
        }

        public async Task SetBrightness(HueBrightness brightness)
        {
            var command = CreateBrightnessCommand(brightness);
            SendCommandAsync(command);
        }

        private LightCommand CreateBrightnessCommand(HueBrightness brightness)
        {
            var command = new LightCommand();
            command.Brightness = brightness.ToValue();
            return command;
        }

        public async Task SetBrightness(HueBrightness brightness, int index)
        {
            var command = CreateBrightnessCommand(brightness);
            SendCommandAsync(command, index);
        }

        private async Task SendCommandAsync(LightCommand command, int index)
        {
            client.SendCommandAsync(command, new string[] { index.ToString() });
        }

        public async Task SetDefault()
        {
            await ShowColour(DefaultColour);
            await SetBrightness(HueBrightness.Maximum);
        }

        public async Task ShowColour(HueColour colour)
        {
            var command = CreateColourCommand(colour);
            SendCommandAsync(command);
        }

        private async Task SendCommandAsync(LightCommand command)
        {
            client.SendCommandAsync(command);
        }

        private LightCommand CreateColourCommand(HueColour colour)
        {
            var command = new LightCommand();
            command.On = true;
            command.SetColor(colour.ToRGBColour());
            return command;
        }

        public async Task ShowColour(HueColour colour, int index)
        {
            var command = CreateColourCommand(colour);
            SendCommandAsync(command, index);
        }

        public async Task ShowColour(HueColour colour, List<int> indexes)
        {
            var command = CreateColourCommand(colour);
            SendCommandAsync(command, indexes);
        }

        private void SendCommandAsync(LightCommand command, List<int> indexes)
        {
            client.SendCommandAsync(command, indexes.Select(i => i.ToString()));
        }

        public async Task SetBrightness(HueBrightness brightness, List<int> indexes)
        {
            var command = CreateBrightnessCommand(brightness);
            SendCommandAsync(command, indexes);
        }

        public async Task TurnOn()
        {
            var command = CreateTurnOnCommand();
            SendCommandAsync(command);
        }

        private LightCommand CreateTurnOnCommand(bool on = true)
        {
            return new LightCommand() { On = on };
        }

        public async Task TurnOn(int index)
        {
            var command = CreateTurnOnCommand();
            SendCommandAsync(command, index);
        }

        public async Task TurnOn(List<int> indexes)
        {
            var command = CreateTurnOnCommand();
            SendCommandAsync(command, indexes);
        }

        public async Task TurnOff()
        {
            var command = CreateTurnOnCommand(false);
            SendCommandAsync(command);
        }

        public async Task TurnOff(int index)
        {
            var command = CreateTurnOnCommand(false);
            SendCommandAsync(command, index);
        }

        public async Task TurnOff(List<int> indexes)
        {
            var command = CreateTurnOnCommand(false);
            SendCommandAsync(command, indexes);
        }

        public async Task Initialize()
        {
            IBridgeLocator locator = new HttpBridgeLocator();
            var bridgeIPs = await locator.LocateBridgesAsync(TimeSpan.FromSeconds(5));
            bridge = bridgeIPs.FirstOrDefault();

            // if there's one or more that comes back, register this app
            if (Connected)
            {
                client = new LocalHueClient(bridge.IpAddress);
                appKey = await client.RegisterAsync(APP_NAME, DEVICE_NAME);
                client.Initialize(appKey);
            }
        }
    }
}
