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
        Red = 0,
        Orange = 1,
        Yellow = 2,
        Green = 3,
        Blue = 4,
        Indigo = 5,
        Violet = 6,
        White = 7
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

        public static HueColour ToHueColour(this int no)
        {

            int index = no % 7;
            while (index < 0)
            {
                index += 7;
            }

            return (HueColour)index;
        }
    }
}
