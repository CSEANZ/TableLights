using Q42.HueApi.ColorConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Q42.HueApi.ColorConverters.Original;

namespace ColourLibrary
{
    public enum HueColour
    {
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Indigo,
        Violet,
        White
    }

    public static class HueColourExtensions
    {
        public static RGBColor ToRGBColour(this HueColour colour)
        {
            RGBColor outColour;
            switch (colour)
            {
                case HueColour.Red:
                    outColour = new RGBColor("FF0000");
                    break;
                case HueColour.Orange:
                    outColour = new RGBColor("FFA500");
                    break;
                case HueColour.Yellow:
                    outColour = new RGBColor("FFFF00");
                    break;
                case HueColour.Green:
                    outColour = new RGBColor("00FF00");
                    break;
                case HueColour.Blue:
                    outColour = new RGBColor("0000FF");
                    break;
                case HueColour.Indigo:
                    outColour = new RGBColor("4B0082");
                    break;
                case HueColour.Violet:
                    outColour = new RGBColor("EE82EE");
                    break;
                case HueColour.White:
                    outColour = new RGBColor("FFFFFF");
                    break;
                default:
                    outColour = new RGBColor("FFFFFF");
                    break;
            }

            return outColour;
        }
    }
}
