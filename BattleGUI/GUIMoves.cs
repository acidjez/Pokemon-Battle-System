namespace PokemonBattle
{
    public class GUIMoves : BattleGui
    {
        public GUIMoves(Move[] moves)           
        {
            Button1 = new Button(moves[0].Name, "Pokemon Classic.ttf", 13, 335, 460)
            {
                IsSelected = true
            };
            if (moves[1] != null)
            {
                Button2 = new Button(moves[1].Name, "Pokemon Classic.ttf", 13, 335, 540);
            }
            if (moves[2] != null)
            {
                Button3 = new Button(moves[2].Name, "Pokemon Classic.ttf", 13, 450, 460);
            }
            if (moves[3] != null)
            {
                Button4 = new Button(moves[3].Name, "Pokemon Classic.ttf", 13, 450, 540);               
            }          
        }   
    } 
}

