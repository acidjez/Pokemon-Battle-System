/*using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattle.@detritus
{

    public class QuitButton : MenuButton
    {



        public QuitButton()

        {
            Name = "Quit";
            IsSelected = false;
        }
        public override void Draw()
        {
            if (IsSelected)
            {
                Selected = Checked;
            }
            else
            {
                Selected = UnChecked;
            }
            SplashKit.DrawText(Name, Color.Blue, Selected, 150, 150, 350);
        }
    }
}
*/