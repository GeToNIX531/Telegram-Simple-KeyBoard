using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramKeyboard
{
    public class Keyboard : IDisposable
    {
        public KeyboardButton[,] rows;

        public int W;
        public int H;
        public Keyboard(int W = 3, int H = 3)
        {
            rows = new KeyboardButton[H, W];
            this.W = W;
            this.H = H;

            for (int y = 0; y < H; y++)
                for (int x = 0; x < W; x++)
                    rows[y, x] = new KeyboardButton(" ");
        }

        public void Add(int Y, int X, string Text) => rows[Y, X].Text = Text;

        public void Dispose()
        {
            rows = null;
            W = 0;
            H = 0;
        }

        public KeyboardButton[][] Get()
        {
            List<List<KeyboardButton>> keys = new List<List<KeyboardButton>>();

            for (int y = 0; y < H; y++)
            {
                keys.Add(new List<KeyboardButton>());

                for (int x = 0; x < W; x++)
                    keys[y].Add(rows[y, x]);
            }

            return keys.Select(T => T.ToArray()).ToArray();
        }
    }
}
