using MongoDB.Bson;
using Newtonsoft.Json;
using Discord;

namespace OctoEngine.Formats
{
    public class Die
    {
        public static readonly Emote SideOneDev = Emote.Parse("<:dice_1:1350935949420269608>");
        public static readonly Emote SideTwoDev = Emote.Parse("<:dice_2:1350936011143905371>");
        public static readonly Emote SideThreeDev = Emote.Parse("<:dice_3:1350936093423304765>");
        public static readonly Emote SideFourDev = Emote.Parse("<:dice_4:1350936138528981066>");
        public static readonly Emote SideFiveDev = Emote.Parse("<:dice_5:1350936185907970213>");
        public static readonly Emote SideSixDev = Emote.Parse("<:dice_6:1350936235295772744>");

        public static readonly Emote SideOneProd = Emote.Parse("<:dice_1:1350944443548700813>");
        public static readonly Emote SideTwoProd = Emote.Parse("<:dice_2:1350944402532466728>");
        public static readonly Emote SideThreeProd = Emote.Parse("<:dice_3:1350944351697764362>");
        public static readonly Emote SideFourProd = Emote.Parse("<:dice_4:1350944306508202064>");
        public static readonly Emote SideFiveProd = Emote.Parse("<:dice_5:1350944258458390598>");
        public static readonly Emote SideSixProd = Emote.Parse("<:dice_6:1350944201717841990>");

        public static Emote[] Sides()
        {
            if (TempStorage.ReadTempValue("server.env") == "prod")
            {
                return new Emote[] { SideOneProd, SideTwoProd, SideThreeProd, SideFourProd, SideFiveProd, SideSixProd };
            } 
            else
            {
                return new Emote[] { SideOneDev, SideTwoDev, SideThreeDev, SideFourDev, SideFiveDev, SideSixDev };
            }
        }
    }
}
