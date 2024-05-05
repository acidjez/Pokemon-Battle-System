using SplashKitSDK;

namespace PokemonBattle
{
    public class Button
    {
        private int _size;
        private int _x;
        private int _y;
        private bool _isSelected;
        private string _font;
        private string _name;
     

        public Button(string name, string font, int size, int X, int Y)
        {      
            _name = name;
            _size = size;
            _x = X;
            _y = Y;
            _font = font;
        }
        public Button(string name, string font, int size, int X, int Y, bool isSelected) 
        { 
            _name=name;
            _size = size;
            _x = X;
            _y = Y;
            _font = font;
            _isSelected = isSelected;        
        }
        public void Draw()
        {

            if (IsSelected)
            {
                SplashKit.DrawText(Name, Color.Red, _font, Size, X, Y);

            }
            else
            {
                SplashKit.DrawText(Name, Color.Black, _font, Size, X, Y);
            }
        }

        public string Name
            {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
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
        public int Size
        { 
            get               
            { 
                return _size; 
            } 
        }
        
        public int X
        {
            get 
            { 
                return _x; 
            }
        }

        public int Y
        {
            get
            {
                return _y;
            }
        }
              
    }
}
