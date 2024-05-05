using SplashKitSDK;

namespace PokemonBattle
{
    public class Pokemon
    {

        private string _name;

        private int _level;
        private int _HP;
        private int _maxHP;
        private int _attack;
        private int _speed;
        private int _defence;

        private bool _isAlive;

        private Move[] _moves = new Move[4];

        private TypeEnum _type;

        private Bitmap _front;
        private Bitmap _back;

        private State _state;

        public Pokemon(string name, int level, TypeEnum type, int maxHP, int attack, int speed, int defence, Move m1, Move m2, Move m3, Move m4, Bitmap front, Bitmap back)
        {
            _name = name;
            _level = level;
            _maxHP = maxHP;
            _HP = maxHP;
            _attack = attack;
            _speed = speed;
            _defence = defence;
            _isAlive = true;

            _moves[0] = m1;
            _moves[1] = m2;
            _moves[2] = m3;
            _moves[3] = m4;

            _front = front;
            _back = back;

            _type = type;

            _state = new Normal(this);
        }


        public void Fight(Pokemon enemy, Move move)
        {
            _state.Fight(enemy, move);           
        }

        public State State
        {
            get
            {
                return _state;
            }
            set 
            { 
                _state = value; 
            }
        }

        public void Draw(Bitmap orientation, double x, double y)
        {
            orientation.Draw(x, y);
        }

        public Bitmap Front 
        {
            get
            {
                return _front;
            }
        }
        public Bitmap Back 
        { 
            get 
            { 
                return _back; 
            } 
        }

        public TypeEnum Type
        {
            get
            {
                return _type;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public int Level 
        {
            get
            {
                return _level;
            }
        }

        public int HP
        {
            get
            {
                return _HP;
            }
            set
            {
                _HP = value;
            }
        }

        public int MaxHP
        {
            get
            {
                return _maxHP;
            }
        }

        public int Attack
        {
            get
            { 
                return _attack; 
            }
        }

        public bool IsAlive
        {
            get
            {
                return _isAlive;
            }
            set
            {
                _isAlive = value;
            }
        }

        public int Defence
        {
            get
            {
                return _defence;
            }
        }

        public int Speed
        { 
            get 
            { 
                return _speed; 
            } 
        }

        public Move[] Move
        {
            get
            {
                return _moves;
            }
        }
    }
}
