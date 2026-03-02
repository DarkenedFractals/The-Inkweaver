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
                On.GhostWorldPresence.SpawnGhost += World_SpawnGhost;
            }
            catch (Exception ex)
            {
                Plugin.Logger.LogError(ex);
            }
        }

        private static bool World_SpawnGhost(On.GhostWorldPresence.orig_SpawnGhost orig, GhostWorldPresence.GhostID ghostID, int karma, int karmaCap, int ghostPreviouslyEncountered, bool playingAsRed)
        {
            try
            {
                if (Custom.rainWorld.progression.currentSaveState.cycleNumber == 0)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Plugin.Logger.LogError(ex);
            }
            return orig(ghostID, karma, karmaCap, ghostPreviouslyEncountered, playingAsRed);
        }
    }
}
