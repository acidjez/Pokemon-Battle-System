using SplashKitSDK;

namespace PokemonBattle
{
    public class HealthBars
    {
        private Pokemon _p, _e;
        public HealthBars(Pokemon p, Pokemon e) 
        { 
            _p = p;
            _e = e;
        }

        public void Draw()
        {
            Color pCol;
            Color eCol;

            double pHealth, eHealth;

            pHealth = (((100*_p.HP)/_p.MaxHP) *2);
            eHealth = (((100*_e.HP)/ _e.MaxHP) *2);
    
            if (pHealth > 40)
            {
                pCol = Color.Green;
            }
            else { pCol = Color.Red; }

            if (eHealth > 40)
            {
                eCol = Color.Green;
            }
            else { eCol = Color.Red; }


            SplashKit.FillRectangle(pCol, 20, 480, pHealth, 20.00);
            SplashKit.DrawRectangle(Color.Black, 20, 480, 200, 20);
            SplashKit.DrawText(_p.Name, Color.Black, "Pokemon Classic.ttf", 20, 20, 500);
            SplashKit.DrawText("Level "+_p.Level, Color.Black, "Pokemon Classic.ttf", 20, 20, 550);
            SplashKit.DrawText(_p.HP+"/"+_p.MaxHP, Color.Black, "Pokemon Classic.ttf", 15, 20, 530);
            if (_p.State.StateEnum != StateEnum.Normal)
            {
                SplashKit.DrawText(_p.State.Name, Color.Black, "Pokemon Classic.ttf", 13, 200, 530);
            }

            SplashKit.FillRectangle(eCol, 20, 20, eHealth, 20);
            SplashKit.DrawRectangle(Color.Black, 20, 20, 200, 20);
            SplashKit.DrawText(_e.Name, Color.Black, "Pokemon Classic.ttf", 20, 20, 40);
            SplashKit.DrawText("Level " + _e.Level, Color.Black, "Pokemon Classic.ttf", 20, 20, 90);
            SplashKit.DrawText(_e.HP + "/" + _e.MaxHP, Color.Black, "Pokemon Classic.ttf", 15, 20, 70);
            if (_e.State.StateEnum != StateEnum.Normal)
            {
                SplashKit.DrawText(_e.State.Name, Color.Black, "Pokemon Classic.ttf", 13, 200, 70);
            }

        }
    }
}
