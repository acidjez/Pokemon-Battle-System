using SplashKitSDK;

namespace PokemonBattle
{
    public abstract class GUIList
    {
        private Player _player;

        private string _font;
        private int _startHeight, _startWidth, _offset, _offsetXtra, _fSize, _noOfThings;
        private PokeOutline _oLine1, _oLine2, _oLine3, _oLine4, _oLine5, _oLine6;
        private Color _clr;

        public GUIList(Player player, Color clr, string font, int fsize, int noOfThings)
        {
            _player = player;
            _font = font;
            _startHeight = 20;
            _startWidth = 20;
            _offset = 50;
            _offsetXtra = 13;
            _clr = clr;
            _fSize = fsize;
            _noOfThings = noOfThings;

            _oLine1 = new PokeOutline(_startWidth - 10, _startHeight)
            {
                IsSelected = true
            };
            _oLine2 = new PokeOutline(_startWidth - 10, _startHeight + (_offset + _offsetXtra));
            _oLine3 = new PokeOutline(_startWidth - 10, _startHeight + (_offset + _offsetXtra) * 2);
            _oLine4 = new PokeOutline(_startWidth - 10, _startHeight + (_offset + _offsetXtra) * 3);
            _oLine5 = new PokeOutline(_startWidth - 10, _startHeight + (_offset + _offsetXtra) * 4);
            _oLine6 = new PokeOutline(_startWidth - 10, _startHeight + (_offset + _offsetXtra) * 5);
        }


        public void DrawOutline()
        {
            _oLine1.Draw();
            _oLine2.Draw();
            _oLine3.Draw();
            _oLine4.Draw();
            _oLine5.Draw();
            _oLine6.Draw();
        }

        public abstract void Draw();

  

        public void Update()
        {
            if (SplashKit.KeyTyped(KeyCode.DownKey))
            {
                SplashKit.Delay(100);
                if (_oLine5.IsSelected)
                {
                    if (_noOfThings > 5)
                    {
                        _oLine5.IsSelected = false;
                        _oLine6.IsSelected = true;
                    }
                }
                if (_oLine4.IsSelected)
                {
                    if (_noOfThings > 4)
                    {
                        _oLine4.IsSelected = false;
                        _oLine5.IsSelected = true;
                    }
                }
                if (_oLine3.IsSelected)
                {
                    if (_noOfThings > 3)
                    {
                        _oLine3.IsSelected = false;
                        _oLine4.IsSelected = true;
                    }
                }
                if (_oLine2.IsSelected)
                {
                    if (_noOfThings > 2)
                    {
                        _oLine2.IsSelected = false;
                        _oLine3.IsSelected = true;
                    }

                }
                if (OLine1.IsSelected)
                {
                    if (_noOfThings > 1)
                    {
                        OLine1.IsSelected = false;
                        OLine2.IsSelected = true;
                    }
                }
            }

            if (SplashKit.KeyTyped(KeyCode.UpKey))
            {
                SplashKit.Delay(100);
                if (_oLine2.IsSelected)
                {
                    _oLine2.IsSelected = false;
                    _oLine1.IsSelected = true;
                }
                if (_oLine3.IsSelected)
                {
                    _oLine3.IsSelected = false;
                    _oLine2.IsSelected = true;
                }
                if (_oLine4.IsSelected)
                {
                    _oLine4.IsSelected = false;
                    _oLine3.IsSelected = true;
                }
                if (_oLine5.IsSelected)
                {
                    _oLine5.IsSelected = false;
                    _oLine4.IsSelected = true;
                }
                if (_oLine6.IsSelected)
                {
                    _oLine6.IsSelected = false;
                    _oLine5.IsSelected = true;
                }
            }


        }

        public PokeOutline OLine1
        {
            get
            {
                return _oLine1;
            }
        }

        public PokeOutline OLine2
        {
            get
            {
                return _oLine2;
            }
        }

        public PokeOutline OLine3
        {
            get
            {
                return _oLine3;
            }
        }

        public PokeOutline OLine4
        {
            get
            {
                return _oLine4;
            }
        }

        public PokeOutline OLine5
        {
            get
            {
                return _oLine5;
            }
        }

        public PokeOutline OLine6
        {
            get
            {
                return _oLine6;
            }
        }

        public Player Player
        {
            get
            {
                return _player;
            }
        }

        public string Font
        {   
            get     
            { 
                return _font; 
            } 
        }

        public int StartHeight
        {
            get 
            { 
                return _startHeight; 
            }
        }
        public int StartWidth
        {
            get 
            { 
                return _startWidth;
            }
        }

        public int Offset
        {
            get 
            {
                return _offset; 
            }
        }
        public int OffsetX
        {
            get
            {
                return _offsetXtra;
            }
        }
        public Color Clr
        {
            get
            {
                return _clr;
            }
        }
        public int FSize
        {
            get 
            { 
                return _fSize;
            }
        }

        public int NoOfThings
        {
            get
            {
                return _noOfThings;
            }
            set 
            { 
                _noOfThings = value; 
            }
        }
    }
}
