
namespace PokemonBattle
{
    public class Normal : State
    {
        public Normal(Pokemon p) :
            base(p)
        {   
            StateEnum = StateEnum.Normal;
            Name = "normal";
        }
    }
}
