using SplashKitSDK;

namespace PokemonBattle
{
    public class Program
    {
        public static void Main()
        {
            
            Move tackle = new NormalMove("Tackle", "Tackels the enemy", 50, 10);
            Move vineWhip = new GrassMove("Vine Whip", "Whip the enemy with your vines", 80, 15);
            Move razorLeaf = new GrassMove("Razor Leaf", "Throw sharp leaves at the enemy", 100, 15);
            Move headbutt = new NormalMove("Headbutt", "Smash the enemy with your skull", 85, 8);

            Move surf = new WaterMove("Surf", "Hit the enemy with a tidal wave", 60, 10);
            Move bubble = new WaterMove("Bubble", "Smack the enemy with bubbles, always crits", 55, 100);

            Move ember = new FireMove("Ember", "Send burning embers at the enemy", 65, 15);
            Move flamethrower = new FireMove("Flamethrower", "High damage fire move", 70, 8);

            Move sing = new SleepMove("Sing", "sing the enemy to sleep", 0, 0);

            Pokemon bulbasaur1 = new Pokemon("Bulbasaur", 30, TypeEnum.Grass, 1000, 50, 45, 48, tackle, vineWhip, razorLeaf, headbutt, new Bitmap("Bulbasaur front", "BulbaFront.png"), new Bitmap("Bulbasaur back", "BulbaBack.png") );
            Pokemon bulbasaur2 = new Pokemon("Bulbasaur", 30, TypeEnum.Grass, 1000, 50, 50, 48, tackle, vineWhip, razorLeaf, headbutt, new Bitmap("Bulbasaur front", "BulbaFront.png"), new Bitmap("Bulbasaur back", "BulbaBack.png"));
            Pokemon squirtle1 = new Pokemon("Squirtle", 29, TypeEnum.Water, 980, 48, 45, 48, tackle, headbutt, surf, bubble, new Bitmap("Squirtle front", "SquirtFront.png"), new Bitmap("Squirtle back", "SquirtBack.png"));
            Pokemon squirtle2 = new Pokemon("Squirtle", 29, TypeEnum.Water, 980, 48, 45, 48, tackle, headbutt, surf, bubble, new Bitmap("Squirtle front", "SquirtFront.png"), new Bitmap("Squirtle back", "SquirtBack.png"));
            Pokemon charmander1 = new Pokemon("Charmander", 28, TypeEnum.Fire, 950, 47, 42, 48, tackle, null , ember, flamethrower, new Bitmap("Charmander front", "CharFront.png"), new Bitmap("Charmander back", "CharBack.png"));
            Pokemon charmander2 = new Pokemon("Charmander", 28, TypeEnum.Fire, 950, 47, 42, 48, tackle, headbutt, ember, flamethrower, new Bitmap("Charmander front", "CharFront.png"), new Bitmap("Charmander back", "CharBack.png"));
            Pokemon eevee1 = new Pokemon("Eevee", 31, TypeEnum.Normal, 1100, 46, 60, 47, tackle, headbutt, tackle, headbutt, new Bitmap("Eevee front", "EeveeFront.png"), new Bitmap("Eevee back", "EeveeBack.png"));
            Pokemon eevee2 = new Pokemon("Eevee", 31, TypeEnum.Normal, 1100, 46, 60, 47, tackle, headbutt, tackle, headbutt, new Bitmap("Eevee front", "EeveeFront.png"), new Bitmap("Eevee back", "EeveeBack.png"));
            Pokemon jigglypuff = new Pokemon("Jigglypuff", 28, TypeEnum.Normal, 950, 44, 52, 40, tackle, headbutt, sing, null, new Bitmap("Jigglypuff front", "jigglypufffront.png"), new Bitmap("Jigglypuff Back", "jigglypuffback.png"));


            HealthItem potion = new HealthItem("Potion", "Restores 200 HP", 200);
            ReviveItem revive = new ReviveItem("Revive", "Brings a pokemon back to life");
            StatusItem restore = new StatusItem("Restore", "Heals pokemon of any status effects");



            Player player = new Player();
            Player enemy = new Player();
            player.PokeList.AddPokemon(bulbasaur1);
            player.PokeList.AddPokemon(jigglypuff);
            player.PokeList.AddPokemon(squirtle1);
            player.PokeList.AddPokemon(charmander1);
            player.PokeList.AddPokemon(eevee1);

            player.Items.Add(potion);
            player.Items.Add(revive);
            player.Items.Add(restore);

           
            enemy.PokeList.AddPokemon(squirtle2);
            enemy.PokeList.AddPokemon(bulbasaur2);
            enemy.PokeList.AddPokemon(eevee2);
            enemy.PokeList.AddPokemon(charmander2);




            BattleField battlefield = new BattleField(player, enemy);
            Window window = new Window("Pokemon Battle", 600, 600);

            do
            {
                SplashKit.ClearScreen();
                SplashKit.ProcessEvents();
                battlefield.Draw();
         
                SplashKit.RefreshScreen(60);


            } while (!window.CloseRequested);











        }
    }
}
