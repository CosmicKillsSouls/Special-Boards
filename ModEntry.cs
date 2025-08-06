using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewValley;
using StardewValley.Menus;

public class ModEntry : Mod
{
    public override void Entry(IModHelper helper)
    {
        helper.Events.GameLoop.DayStarted += OnDayStarted;
        GameLocation.RegisterTileAction("CosmicKillsSouls.SpecialBoards_HelpWantedBoard", handleHelpWantedBoard);
        GameLocation.RegisterTileAction("CosmicKillsSouls.SpecialBoards_SpecialOrder", handleSpecialOrderBoard);
        GameLocation.RegisterTileAction("CosmicKillsSouls.SpecialBoards_QIQuest", handleQIQuest);
    }

    private bool handleHelpWantedBoard(GameLocation location, string[] args, Farmer player, Point point)
    {
        Game1.activeClickableMenu = new Billboard(true);
        return true;
    }
    private bool handleSpecialOrderBoard(GameLocation location, string[] args, Farmer player, Point point)
    {
        Game1.activeClickableMenu = new SpecialOrdersBoard();
        return true;
    }
    private bool handleQIQuest(GameLocation location, string[] args, Farmer player, Point point)
    {
        Game1.activeClickableMenu = new SpecialOrdersBoard("Qi");
        return true;
    }
    private void OnDayStarted(object sender, EventArgs e)
    {
        if ((Game1.year == 1 && Game1.dayOfMonth >= 14) || (Game1.year == 1 && Game1.season == Season.Summer) || (Game1.year == 1 && Game1.season == Season.Fall) || (Game1.year == 1 && Game1.season == Season.Winter) || (Game1.year > 1))
        {
            if (!Game1.player.hasOrWillReceiveMail("CosmicKillsSouls.HelpWantedBoard"))
            {
                Game1.addMail("CosmicKillsSouls.HelpWantedBoard");
            }
        }
        if ((Game1.year == 1 && Game1.season == Season.Fall && Game1.dayOfMonth >= 9) || (Game1.year == 1 && Game1.season == Season.Winter) || (Game1.year > 1))
        {
            if (!Game1.player.hasOrWillReceiveMail("CosmicKillsSouls.SpecialOrderBoard"))
            {
                Game1.addMail("CosmicKillsSouls.SpecialOrderBoard");
            }
        }
        if (Game1.netWorldState.Get().GoldenWalnutsFound >= 120)
        {
            if (!Game1.player.hasOrWillReceiveMail("CosmicKillsSouls.QIQuestBoard"))
            {
                Game1.addMail("CosmicKillsSouls.QIQuestBoard");
            }
        }
    }
}