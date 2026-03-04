#pragma warning disable IDE0130 // Namespace does not match folder structure
#pragma warning disable CA1707 // Identifiers should not contain underscores

using MoreSlugcats;

namespace Inkweaver;

internal class Player_Hooks
{
    public static void ApplyHooks()
    {
        On.Player.ctor += Player_ctor;
        On.MoreSlugcats.AncientBot.ctor += AncientBot_ctor;
    }

    private static void AncientBot_ctor(On.MoreSlugcats.AncientBot.orig_ctor orig, AncientBot self, Vector2 initPos, Color color, Creature tiedToObject, bool online)
    {
        try
        {
            Player? player = tiedToObject as Player;
            if (player?.SlugCatClass == Enums.Inkweaver)
            {
                color = new Color(0.2f, 0f, 1f);
            }
        }
        catch (Exception ex)
        {
            Plugin.Logger.LogError(ex);
        }
        orig(self, initPos, color, tiedToObject, online);
    }
    private static void Player_ctor(On.Player.orig_ctor orig, Player self, AbstractCreature abstractCreature, World world)
    {
        orig(self, abstractCreature, world);
        SaveState saveState = world.game.GetStorySession.saveState;
        if (saveState.saveStateNumber == Enums.Inkweaver)
        {
            saveState.deathPersistentSaveData.ripMoon = true;
        }
    }
}