using SplashKitSDK;

namespace PokemonBattle
{
    public class PokeOutline
    {
        private double _x, _y, _width, _height;
        private bool _isSelected;

        public PokeOutline(double x, double y)
        {
            _isSelected = false;
            _x = x;
            _y = y;
            _width = 580;
            _height = 40;

        }

        public bool IsSelected
        { 
            get 
            { 
                return _isSelected; 
            } 
            set 
            { 
                _isSelected = value; 
            }
        }

        public void Draw()
        {
            if (_isSelected)
            {
                SplashKit.DrawRectangle(Color.Black, _x, _y, _width, _height);
            }
        }
    }
}
