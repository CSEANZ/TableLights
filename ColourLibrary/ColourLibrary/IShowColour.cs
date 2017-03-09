using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColourLibrary
{
    public interface IShowColour
    {
        Task Initialize();
        Task Cycle();
        Task Cycle(int index);
        Task Cycle(List<int> indexes);
        Task SetDefault();
        Task TurnOn();
        Task TurnOn(int index);
        Task TurnOn(List<int> indexes);
        Task TurnOff();
        Task TurnOff(int index);
        Task TurnOff(List<int> indexes);
        Task ShowColour(HueColour colour);
        Task ShowColour(HueColour colour, int index);
        Task ShowColour(HueColour colour, List<int> indexes);
        Task SetBrightness(HueBrightness brightness);
        Task SetBrightness(HueBrightness brightness, int index);
        Task SetBrightness(HueBrightness brightness, List<int> indexes);
        int Count { get; }
        HueColour DefaultColour { get; set; }
    }


}
