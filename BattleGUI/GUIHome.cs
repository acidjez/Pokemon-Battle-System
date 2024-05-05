namespace PokemonBattle
{
    public class GUIHome : BattleGui
    {
        public GUIHome()      
        {
            //buttons for home gui screen, fight, item, pokemon and run
            Button1= new Button("Fight", "Pokemon Classic.ttf", 20, 320, 460, true);
            Button2 = new Button("Pokemon", "Pokemon Classic.ttf", 20, 320, 540);
            Button3= new Button("Items", "Pokemon Classic.ttf", 20, 480, 460);
            Button4= new Button("Run", "Pokemon Classic.ttf", 20, 520, 540);
        }
    }
}
