using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramKeyboard
{
    public class Container
    {
        private static List<Key> array;

        public static void Init()
        {
            array = new List<Key>();
        }

        public static bool Add(string Name, Keyboard Keyboard)
        {
            if (Contains(Name) == true) return false;

            array.Add(new Key(Name, Keyboard));
            return true;
        }
        public static bool Remove(string Name)
        {
            int id = -1;
            for (int i = 0; i < array.Count; i++)
                if (array[i].Name == Name)
                    id = i;

            if (id == -1)
                return false;

            array.RemoveAt(id);
            return true;
        }

        public static bool Contains(string Name)
        {
            foreach (var item in array)
                if (item.Name == Name)
                    return true;

            return false;
        }
        public static bool Contains(string Name, out Keyboard Keyboard)
        {
            foreach (var item in array)
                if (item.Name == Name)
                {
                    Keyboard = item.Keyboard;
                    return true;
                }

            Keyboard = null;
            return false;
        }


        private class Key
        {
            public string Name;
            public Keyboard Keyboard;

            public Key(string Name, Keyboard Keyboard)
            {
                this.Name = Name;
                this.Keyboard = Keyboard;
            }
        }
    }
}
