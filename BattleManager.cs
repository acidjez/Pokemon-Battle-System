using SplashKitSDK;
using System.Timers;

namespace PokemonBattle
{
    public class BattleManager
    {          
        private int _enemyMove, _playerMove;

        private List<ICommand> _commandList;
    
        BattleField _bf;

        private static System.Timers.Timer? _enemyAttackTimer = new System.Timers.Timer();
        private static System.Timers.Timer? _playerAttackTimer = new System.Timers.Timer();

        public BattleManager(BattleField a)
        {
            _bf = a;   
            _commandList = new List<ICommand>();          
        }

    public void Update()
        {    
            //execute all  commands
            foreach (ICommand c  in _commandList)
            {
                c.Execute();
            }
               
           //after all commands executed, clear execute list
               
            _commandList.Clear();


            if (_bf.PlayerPokemon.HP == 0)
            {
                _bf.PlayerPokemon.IsAlive = false;
            }

            ///if enemy dies, change isalive status, put the next poke in the list on the bf and 
            ///clear all remaining commands
            if (_bf.EnemyPokemon.HP <=0)
            {
                _bf.EnemyPokemon.IsAlive = false;
                
                if (_bf.Enemy.PokeList.GetNext() != null)
                {
                    _bf.EnemyPokemon = _bf.Enemy.PokeList.GetNext();
                    _bf.GuiManager.NewHealthBar();
                    _commandList.Clear();
                }
                else
                {
                    _commandList.Clear();         
                    _bf.GuiManager.AddMessage(new BattleMessage("Enemy is out of usable Pokemon. You win $100", Color.Black, _bf.GuiManager.Font, 13, 20, 180));
                }
            }           
        }

        public void EnemyTurn(int wait)
        {
            if (_bf.EnemyPokemon.IsAlive)
            {
                Random rnd = new Random();         ///random attach generator
                _enemyMove = rnd.Next(0, 3);

                while (_bf.EnemyPokemon.Move[_enemyMove] == null)     ///reroll random no if move is null
                {
                    _enemyMove = rnd.Next(0, 3);
                }

                ///add fight command to command list
                _commandList.Add(new AttackCommand(_bf.EnemyPokemon, _bf.PlayerPokemon, _bf.EnemyPokemon.Move[_enemyMove], wait));
                ///cursed stuff to make the pokemon wait their turn 

                _enemyAttackTimer = new System.Timers.Timer(wait)
                {
                    AutoReset = false,
                    Enabled = true
                };
                _enemyAttackTimer.Elapsed += AddEnemyMessage;
            }
        }

        public void PlayerTurn(int wait, int moveNo)
        {       
            _playerMove = moveNo;

                ///add fight command to command list
            _commandList.Add(new AttackCommand(_bf.PlayerPokemon, _bf.EnemyPokemon, _bf.PlayerPokemon.Move[moveNo], wait));
            
            ///cursed stuff to make the pokemon wait their turn
            _playerAttackTimer = new System.Timers.Timer(wait)
            {
                AutoReset = false,
                Enabled = true
            };
            _playerAttackTimer.Elapsed += AddPlayerMessage;    
        }

        private void AddEnemyMessage(Object? source, ElapsedEventArgs e)
        {
            if (_bf.EnemyPokemon.State.StateEnum != StateEnum.Asleep && _bf.EnemyPokemon.IsAlive)
            {
                _bf.GuiManager.AddMessage(new BattleMessage("Enemy " + _bf.EnemyPokemon.Name + "used " + _bf.EnemyPokemon.Move[_enemyMove].Name, Color.Black, _bf.GuiManager.Font, 13, 20, 150));

                _bf.GuiManager.EnemyAnimation();
            }
            if (_bf.EnemyPokemon.State.StateEnum != StateEnum.Normal)
            {///print message if enemy has state changed
                _bf.GuiManager.AddMessage(new BattleMessage("Enemy is " + _bf.EnemyPokemon.State.Name, Color.Black, _bf.GuiManager.Font, 13, 20, 200));
            }
        }


        private void AddPlayerMessage(Object? source, ElapsedEventArgs e)
        {
            if (_bf.PlayerPokemon.State.StateEnum != StateEnum.Asleep)
            {
                _bf.GuiManager.AddMessage(new BattleMessage("You used " + _bf.PlayerPokemon.Move[_playerMove].Name + " against enemy", Color.Black, _bf.GuiManager.Font, 13, 200, 400));
                _bf.GuiManager.PlayerAnimation();
            }
            if (_bf.PlayerPokemon.State.StateEnum != StateEnum.Normal)
            {
                _bf.GuiManager.AddMessage(new BattleMessage("You are " + _bf.PlayerPokemon.State.Name, Color.Black, _bf.GuiManager.Font, 13, 20, 250));
            }
        }

        public void AddCommand(ICommand i)
        {
            _commandList.Add(i);
        }
    }
}
