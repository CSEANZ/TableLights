using ColourLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SurfaceDial
{


    public sealed partial class MainPage : Page
    {
        public enum CurrentTool
        {
            Bright,
            Color
        }

        private CurrentTool _currentTool;
        private readonly List<SolidColorBrush> _namedBrushes;
        private int _selBrush;

        public MainPage()
        {
            this.InitializeComponent();
            // Create a reference to the RadialController.
            var supported = RadialController.IsSupported();
            if (!supported)
            {
                return;
            }
            var controller = RadialController.CreateForCurrentView();

            // Create the icons for the dial menu
            var iconBright = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/bright.png"));
            var iconColor = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/Color.png"));

            // Create the items for the menu
            var itemBright = RadialControllerMenuItem.CreateFromIcon("Bright", iconBright);
            var itemColor = RadialControllerMenuItem.CreateFromIcon("Color", iconColor);

            // Add the items to the menu
            controller.Menu.Items.Add(itemBright);
            controller.Menu.Items.Add(itemColor);

            // Select the correct tool when the item is selected
            itemBright.Invoked += (s, e) => _currentTool = CurrentTool.Bright;
            itemColor.Invoked += (s, e) => _currentTool = CurrentTool.Color;

            // Get all named colors and create brushes from them
            _namedBrushes = typeof(Colors).GetRuntimeProperties().Select(c => new SolidColorBrush((Color)c.GetValue(null))).ToList();

            controller.RotationChanged += ControllerRotationChanged;

            // Leave only the Volume default item - Zoom and Undo won't be used
            RadialControllerConfiguration config = RadialControllerConfiguration.GetForCurrentView();
            config.SetDefaultMenuItems(new[] { RadialControllerSystemMenuItemKind.Volume });

        }

        private void ControllerRotationChanged(RadialController sender, RadialControllerRotationChangedEventArgs args)
        {
            switch (_currentTool)
            {
                case CurrentTool.Bright:
                    Rotate.Angle += args.RotationDeltaInDegrees;
                    break;
                case CurrentTool.Color:
                    _selBrush += (int)(args.RotationDeltaInDegrees / 10);
                    if (_selBrush >= _namedBrushes.Count)
                        _selBrush = 0;
                    if (_selBrush < 0)
                        _selBrush = _namedBrushes.Count - 1;
                    Rectangle.Fill = _namedBrushes[(int)_selBrush];
                    break;
                default:
                    break;
            }

        }

    }
}

