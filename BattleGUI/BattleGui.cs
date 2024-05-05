
using SplashKitSDK;

namespace PokemonBattle
{
    public abstract class BattleGui
    {
        private Button? _button1, _button2, _button3, _button4;
        public BattleGui() 
        {
            
        }

        //draw each button in gui
        public void Draw()
        {
            
            _button1.Draw();
            if (_button2 != null) 
            {
                _button2.Draw();
            }
            if (_button3 != null) 
            {
                _button3.Draw();
            }          
            if (_button4 != null) 
            {
                _button4.Draw();
            }
            Update();
        }
        //check for user input, sets approprate buttons IsSelected to true
        private void Update()
        {
            if (SplashKit.KeyTyped(KeyCode.DownKey))
            {
                if (_button1 != null && _button1.IsSelected && _button2 != null)
                {
                    _button1.IsSelected = false;
                    _button2.IsSelected = true;
                }
                if (_button3 != null && _button3.IsSelected && _button4 != null)
                {
                    _button3.IsSelected = false;
                    _button4.IsSelected = true;
                }
            }


            if (SplashKit.KeyTyped(KeyCode.UpKey))
            {
                if (_button2 != null && _button2.IsSelected && _button1 != null)
                {
                    _button2.IsSelected = false;
                    _button1.IsSelected = true;               
                }

                if (_button4 != null && _button4.IsSelected && _button3 != null)
                {
                    _button4.IsSelected = false;
                    _button3.IsSelected = true;
                }
            }

            if (SplashKit.KeyTyped(KeyCode.RightKey))
            {
                if (_button1 != null && _button1.IsSelected && _button3 != null)
                {
                    _button1.IsSelected = false;
                    _button3.IsSelected = true;
                }

                if (_button2 != null && _button2.IsSelected && _button4 != null)
                {
                    _button2.IsSelected = false;
                    _button4.IsSelected = true;
                }
            }

            if (SplashKit.KeyTyped(KeyCode.LeftKey))
            {
                if (_button3 != null && _button3.IsSelected && _button1 != null)
                {
                    _button3.IsSelected = false;
                    _button1.IsSelected = true;
                }
                if (_button4 != null && _button4.IsSelected && _button2 != null)
                {
                    _button4.IsSelected = false;
                    _button2.IsSelected = true;
                }
            }
        }
        //propertys for buttons
        public Button Button1
        {
            get
            {
                return _button1;
            }
            set
            { 
                _button1 = value; 
            }
        }


        public Button Button2
        {
            get
            {
                return _button2;
            }
            set
            {
                _button2 = value;
            }
        }

        public Button Button3
        {
            get
            {
                return _button3;
            }
            set
            {
                _button3 = value;
            }
        }

        public Button Button4
        {
            get
            {
                return _button4;
            }
            set
            {
                _button4 = value;
            }
        }
    }
}
