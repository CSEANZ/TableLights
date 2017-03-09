namespace ColourLibrary
{
    public enum HueBrightness
    {
        Minumum,
        Low,
        Medium,
        High,
        Maximum
    }

    public static class HueBrightnessExtensions
    {
        public static byte ToValue(this HueBrightness brightness)
        {
            byte brightnessOut;

            switch (brightness)
            {
                case HueBrightness.Minumum:
                    brightnessOut = 0x20;
                    break;
                case HueBrightness.Low:
                    brightnessOut = 0x40;
                    break;
                case HueBrightness.Medium:
                    brightnessOut = 0x80;
                    break;
                case HueBrightness.High:
                    brightnessOut = 0xB0;
                    break;
                case HueBrightness.Maximum:
                    brightnessOut = 0xFF;
                    break;
                default:
                    brightnessOut = 0xFF;
                    break;
            }

            return brightnessOut;
        }

        public static HueBrightness ToHueBrightness(this int input)
        {
            var index = input % 5;
            while (index < 0)
            {
                index += 5;
            }

            return (HueBrightness)index;
        }
    }
}