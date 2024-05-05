namespace PokemonBattle
{
    public class BattleField
    {
        Player _p, _e;
        Pokemon _playerPokemon, _enemyPokemon;
        BattleManager _battleManager;
        GUIManager _guiManager;

       
        public BattleField(Player p, Player e)
        {
            _p = p;
            _e = e;
            _playerPokemon = p.PokeList.List[0];
            _enemyPokemon = e.PokeList.List[0];
            _battleManager = new BattleManager(this);
            _guiManager = new GUIManager(this);           
        }

        public void Draw()
        {
            _guiManager.Update();
            _battleManager.Update();
            _guiManager.Draw();
        }


    public Pokemon PlayerPokemon
    {
        set
        {    
         _playerPokemon = value;      
        }
        get
        {
            return _playerPokemon;
        }
    }

    public Pokemon EnemyPokemon
    {
        set
        {
            _enemyPokemon = value;        
        }
        get
        {
            return _enemyPokemon;
        }
    }


        public Player Player
        {
            get
            {
                return _p;
            }
        }

        public Player Enemy
        {
            get 
            { 
                return _e; 
            }
        }

        public GUIManager GuiManager
        {
            get
            { 
                return _guiManager; 
            }
        }


        public BattleManager BattleManager 
        { 
            get 
            { 
                return _battleManager; 
            } 
        }
}
}
