# Telegram-Simple-KeyBoard
Simple Work with Telegram KeyBoard


Example:

Container.Init();
using (var keyboard = new Keyboard(1, 1))
{
    var keyInputer = keyboard.Input("Hello");
    keyInputer.InContain("Main");
}

...

if (Container.Contains("Main", out Keyboard Main) == false) return;
var keys = Main.Get();
