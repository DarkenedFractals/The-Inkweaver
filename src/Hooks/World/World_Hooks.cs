#pragma warning disable IDE0130 // Namespace does not match folder structure
using RWCustom;

namespace Inkweaver
{
    internal class World_Hooks
    {
        public static void ApplyHooks()
        {
            try
            {
                On.GhostWorldPresence.SpawnGhost += GhostWorldPresence_SpawnGhost;
            }
            catch (Exception ex)
            {
                Plugin.Logger.LogError(ex);
            }
        }

        public static bool GhostWorldPresence_SpawnGhost(On.GhostWorldPresence.orig_SpawnGhost orig, GhostWorldPresence.GhostID ghostID, int karma, int karmaCap, int ghostPreviouslyEncountered, bool playingAsRed)
        {
            //Plugin.Logger.LogDebug("GhostWorldPresence_SpawnGhost : Trying");
            try
            {
                SaveState saveState = Custom.rainWorld.progression.currentSaveState;
                if (saveState.saveStateNumber == Enums.Inkweaver && saveState.cycleNumber == 0)
                {
                    //Plugin.Logger.LogDebug("GhostWorldPresence_SpawnGhost : Returning false");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Plugin.Logger.LogError(ex);
            }
            //Plugin.Logger.LogDebug("GhostWorldPresence_SpawnGhost : Returning orig");
            return orig(ghostID, karma, karmaCap, ghostPreviouslyEncountered, playingAsRed);
        }
    }
}
