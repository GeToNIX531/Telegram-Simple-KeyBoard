using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramKeyboard
{
    public class KeyboardIputer : Keyboard
    {
        public int lastUpdate = 0;

        public KeyboardIputer(Keyboard Keyboard)
        {
            this.rows = Keyboard.rows;
            this.H = Keyboard.H;
            this.W = Keyboard.W;
        }

        public int CurentW => lastUpdate % W;
        public int CurentH => lastUpdate / W % H;
        public void Next() => lastUpdate++;
    }

    public static class Extension
    {
        public static bool InContain(this Keyboard Keyboard, string Name) => Container.Add(Name, Keyboard);

        public static KeyboardIputer Input(this Keyboard Keyboard, string Text)
        {
            var result = new KeyboardIputer(Keyboard);
            result.Add(result.CurentH, result.CurentW, Text);
            return result;
        }

        public static KeyboardIputer Input(this KeyboardIputer Inputer, string Text)
        {
            Inputer.Next();
            Inputer.Add(Inputer.CurentH, Inputer.CurentW, Text);
            return Inputer;
        }

        public static Keyboard ToKeyboard(this KeyboardIputer Inputer) => Inputer;
    }
}
