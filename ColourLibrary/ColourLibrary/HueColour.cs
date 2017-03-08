using Q42.HueApi.ColorConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static double[] ToCTColour(this HueColour colour)
        {
            double[] outColour = new double[2];
            switch (colour)
            {
                case HueColour.Red:
                    outColour[0] = 0.3972d;
                    outColour[1] = 0.4564d;
                    break;
                case HueColour.Orange:
                    outColour[0] = 0.5425d;
                    outColour[1] = 0.4196d;
                    break;
                case HueColour.Yellow:
                    outColour[0] = 0.5425d;
                    outColour[1] = 0.4196d;
                    break;
                case HueColour.Green:
                    outColour[0] = 0.41d;
                    outColour[1] = 0.51721d;
                    break;
                case HueColour.Blue:
                    outColour[0] = 0.1691d;
                    outColour[1] = 0.0441d;
                    break;
                case HueColour.Indigo:
                    outColour[0] = 0.3972d;
                    outColour[1] = 0.4564d;
                    break;
                case HueColour.Violet:
                    outColour[0] = 0.3972d;
                    outColour[1] = 0.4564d;
                    break;
                case HueColour.White:
                    outColour[0] = 0.3972d;
                    outColour[1] = 0.4564d;
                    break;
                default:
                    outColour[0] = 0.3972d;
                    outColour[1] = 0.4564d;
                    break;
            }

            return outColour;
        }
    }
}
