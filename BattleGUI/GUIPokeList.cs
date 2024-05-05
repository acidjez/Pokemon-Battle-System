
using SplashKitSDK;

namespace PokemonBattle
{
    public class GUIPokeList :GUIList
    {
        public GUIPokeList(Player player, Color clr, string font, int fsize, int noOfThings) :
            base(player, clr, font, fsize, noOfThings)
        {}

        public override void Draw()
        {
            int y = StartHeight, x = StartWidth;

  
            foreach (Pokemon pok in Player.PokeList.List)
            {

                Color pCol;
                

                double pHealth = (((100 * pok.HP) /pok.MaxHP) * 2);
                if (pHealth > 40)
                {
                    pCol = Color.Green;
                }
                else { pCol = Color.Red; }
                SplashKit.DrawText(pok.Name, Clr, Font, FSize, x, y);
                y += OffsetX;
                SplashKit.FillRectangle(pCol, x+160, y, pHealth, 20);
                SplashKit.DrawText(pok.HP+"/"+pok.MaxHP, Clr, Font, FSize, x+400, y);

                SplashKit.DrawText("Level "+pok.Level.ToString(), Clr, Font, FSize, x, y);
                
          
                y += Offset;
            }
            Update();
            DrawOutline();
        }

     
        //returns pokemon associated with outline object whos IsSelected is true
        public Pokemon? PokeReturn()
        {
            if (OLine1.IsSelected)
            {
               
                    return Player.PokeList.List[0];
                
            }
            if (OLine2.IsSelected)
            {
               
                    return Player.PokeList.List[1];
             
            }
            if (OLine3.IsSelected)
            {
             
                    return Player.PokeList.List[2];
                }
          
            if (OLine4.IsSelected)
            {
              
                    return Player.PokeList.List[3];
             
            }
            if (OLine5.IsSelected)
            {
             
                    return Player.PokeList.List[4];
                
            }
            if (OLine6.IsSelected)
            {
             
                    return Player.PokeList.List[5];
              
            }
            return null;
        }
    }
}
