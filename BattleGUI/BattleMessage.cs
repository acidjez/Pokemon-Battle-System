using SplashKitSDK;

namespace PokemonBattle
{
    public class BattleMessage
    {
        private string _msg;
        private string _font;
        private Color _clr;
        private int _size;
        private int _x;
        private int _y;
      
        public BattleMessage(string msg, Color clr, string font, int size, int x, int y) 
        { 
            _msg = msg;
            _font = font;
            _clr = clr; 
            _size = size;
            _x = x;
            _y = y;
        }
     
      //draws battle message on the screen with given screen locations and message string
        public void Draw()
        {    
            SplashKit.DrawText(_msg, _clr, _font, _size, _x, _y);            
        }
    }
}
