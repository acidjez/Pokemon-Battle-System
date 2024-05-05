using SplashKitSDK;

namespace PokemonBattle
{
    public class GUIManager
    {
        private GUIHome _guiHome;
        private GUIPokeList _guiPokelist;
        private GUIItemList _guiItemList;
        private HealthBars _healthBar;
        private BattleGui _battleGui;
        private bool _inMovesList, _inPokeList, _inHomeList, _inItemList; 
        private string _font;
        private int _playerMove;
        private Item? _tmpItem;
        private List<BattleMessage> _battleMessage;


        private Point2D _playerPos, _enemyPos;


        BattleField _bf;

        public GUIManager(BattleField bf) 
        {
            _bf = bf;

            _font = "Pokemon Classic.ttf";

            _guiHome = new GUIHome();
         
            _guiPokelist = new GUIPokeList(bf.Player, Color.Black, _font, 13, bf.Player.PokeList.List.Count());
            _guiItemList = new GUIItemList(bf.Player, Color.Black, _font, 13, bf.Player.Items.Count());

            _healthBar = new HealthBars(bf.PlayerPokemon, bf.EnemyPokemon);

            _inMovesList = false;
            _inHomeList = true;
            _inItemList = false;
            _inPokeList = false;

            _tmpItem = null;

            _battleMessage = new List<BattleMessage>();

            _battleGui = _guiHome;

            _playerPos = new Point2D
            {
                X = -50,
                Y = 200
            };
            _enemyPos = new Point2D
            {
                X = 300,
                Y = -70
            };
        }

        public void Draw()
        {
            //asks pokemon, GUI and healthbar objects to draw themselves if in the relevant screens
            if (_inMovesList || _inHomeList)
            {
                _bf.PlayerPokemon.Draw(_bf.PlayerPokemon.Back, _playerPos.X, _playerPos.Y);
                _bf.EnemyPokemon.Draw(_bf.EnemyPokemon.Front, _enemyPos.X, _enemyPos.Y);
                _battleGui.Draw();
             
                _healthBar.Draw();
                SplashKit.DrawRectangle(Color.Black, 300, 440, 290, 150);
         
                foreach (BattleMessage bm in _battleMessage)
                {
                    bm.Draw();            //draw all battle messages
                }             
            }
            //asks pokeList object to draw if in relevant screen
            if (_inPokeList)
            {
                _guiPokelist.Draw();
            }
            //asks itemList object to draw itself if in relevant screen
            if (_inItemList)
            {
                _guiItemList.Draw();
            }
        }
        //check for user input and excecute approptate actions
        public void Update()
        {
            /////select option from home gui
            if (SplashKit.KeyTyped(KeyCode.ReturnKey) && _inHomeList)
            {              
                SplashKit.Delay(100);
                _battleMessage.Clear();    //clear all messages once player selects option
                ///moves
                if (_battleGui.Button1.IsSelected) //user selects fight
                {
                    //draw moves gui
                    _battleGui = new GUIMoves(_bf.PlayerPokemon.Move);
                    _inHomeList = false;
                    _inMovesList = true;
                    SplashKit.Delay(100);
                    return;                  
                }
                ///pokemon
                if (_battleGui.Button2.IsSelected) //user selects pokemon
                {
                    _inPokeList = true;
                    _inHomeList = false;
                    SplashKit.Delay(100);
                    return;
                }
                ///items
                if (_battleGui.Button3.IsSelected) //user selects items
                {
                    _inHomeList = false;
                    _inItemList = true;
                    SplashKit.Delay(100);
                    return;
                }
                if (_battleGui.Button4.IsSelected)
                {
                    Environment.Exit(0);
                }
            }

            /////if move selected
            if (SplashKit.KeyTyped(KeyCode.ReturnKey) && _inMovesList)
            {
                if (_battleGui.Button1.IsSelected)
                {
                    _playerMove = 0;
                }
                if (_battleGui.Button2 != null && _battleGui.Button2.IsSelected)
                {
                    _playerMove = 1;
                }
                if (_battleGui.Button3 != null && _battleGui.Button3.IsSelected)
                {
                    _playerMove = 2;
                }
                if (_battleGui.Button4 != null && _battleGui.Button4.IsSelected)
                {
                    _playerMove = 3;
                }

   
                ///if player pokemon speed is faster
                if (_bf.PlayerPokemon.Speed >= _bf.EnemyPokemon.Speed)
                {
                    _bf.BattleManager.PlayerTurn(500, _playerMove);
                    _bf.BattleManager.EnemyTurn(1500);

                }
                else ///if enemy pokemon speed is faster
                {
                    _bf.BattleManager.EnemyTurn(500);
                    _bf.BattleManager.PlayerTurn(1500, _playerMove);
                }

     
                //set gui to home
                _battleGui = _guiHome;
                _inMovesList = false;
                _inItemList = false;
                _inHomeList = true;
            }

            ////return selected pokemon from list and send to battlefield
            if (_inPokeList && SplashKit.KeyTyped(KeyCode.ReturnKey) && _tmpItem==null)
            {
                if (_guiPokelist.PokeReturn() != null)
                {
                    _bf.PlayerPokemon = _guiPokelist.PokeReturn();  
                    NewHealthBar();               //create new healthbars

                    _battleGui = _guiHome;
                    _inHomeList = true;
                    _inMovesList = false;
                    _inPokeList = false;
                }
            }


            if (_inPokeList && SplashKit.KeyTyped(KeyCode.ReturnKey) && _tmpItem != null)
            {
                SplashKit.Delay(100);
                _bf.BattleManager.AddCommand(new UseItemCommand(_bf.Player, _guiPokelist.PokeReturn(), _tmpItem));
                _guiItemList.noOfThingsUpdate();
                _inPokeList = false;
                _inHomeList = true;
                _tmpItem = null;
            }

            ////return to home gui if esc pressed
            if ((_inPokeList || _inItemList || _inMovesList) && SplashKit.KeyTyped(KeyCode.EscapeKey))
            {
                _inPokeList = false;
                _inItemList = false;
                _inMovesList = false;
                _inHomeList = true;
                _battleGui = _guiHome;
                SplashKit.Delay(100);
            }

            //if player pokemon dies, send user to poke screen
            if (_bf.PlayerPokemon.HP == 0)
            {
              //  _bf.PlayerPokemon.IsAlive = false;
                _inHomeList = false;
                _inMovesList = false;
                _inItemList = false;
                _inPokeList = true;
            }

            /////use item from list
            if (_inItemList && SplashKit.KeyTyped(KeyCode.ReturnKey))
            {
                SplashKit.Delay(100);
                _tmpItem = _guiItemList.ReturnItem();
                _inItemList = false;
                _inPokeList = true;
            }

            AnimationReset();
        }

        ///create new healthbars for new pokemon
        public void NewHealthBar()
        {
            _healthBar = new HealthBars(_bf.PlayerPokemon, _bf.EnemyPokemon);
        }

        //moves bitmap for animation
        public void PlayerAnimation()
        {
            _playerPos.X += 40;
        }

        public void EnemyAnimation()
        {
            _enemyPos.X -= 40;
        }

        /// curses to make animation happen
        private void AnimationReset()
        {
            if (_playerPos.X != -50)
            {           
                _playerPos.X -= 1;               
            }
            if (_enemyPos.X != 300)
            {
                _enemyPos.X += 1;              
            }
        }
        //adds battle message to list
        public void AddMessage(BattleMessage bm)
        {
            _battleMessage.Add(bm);
        }
        public void ClearMessages()
        {
            _battleMessage.Clear();
        }

        public string Font
        {
            get
            {
                return _font;
            }
        }
    }
}


