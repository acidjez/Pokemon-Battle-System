using SplashKitSDK;

namespace PokemonBattle
{
   
    public class GUIItemList : GUIList
    {
        public GUIItemList(Player player, Color clr, string font, int fsize, int noOfThings) :
            base(player, clr, font, fsize, noOfThings)
        {}

        public override void Draw()
        {
            int y = StartHeight, x = StartWidth;
            if (Player.Items.Count > 0)
            {
                foreach (Item i in Player.Items)
                {
                  
                        SplashKit.DrawText(i.Name, Clr, Font, FSize, x, y);
                        SplashKit.DrawText(i.Desc, Clr, Font, FSize - 4, x + 110, y);
                        y = y + Offset+OffsetX;                   
                }
                Update();
                DrawOutline();            
            }
            else
            {
                SplashKit.DrawText("You have no items", Clr, Font, FSize, x, y);
            }    
        }

        public void noOfThingsUpdate()
        {
            NoOfThings -= 1;
        }
     
        //Returns item associated with outline object whos IsSelected is true
        public Item ReturnItem()
        {
            if (OLine1.IsSelected)
            {
                return Player.Items[0];
            }
            if (OLine2.IsSelected)
            {
                return Player.Items[1];
            }
            if (OLine3.IsSelected)
            {
                return Player.Items[2];
            }
            if (OLine4.IsSelected)
            {
                return Player.Items[3];
            }
            if (OLine5.IsSelected)
            {
                return Player.Items[4];
            }                   
                return Player.Items[5];         
        }
    }
}
