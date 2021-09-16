using HarmonyLib;
using QModManager.API.ModLoading;
using QModManager.API;
using System.Reflection;

namespace No_Feedback_Reminder
{
    // Your main patching class must have the QModCore attribute (and must be public)
    [QModCore]
    public static class Main
    {
        // Your patching method must have the QModPatch attribute (and must be public)
        [QModPatch]
        public static void Patch()
        {
            // Add your patching code here
            //QModServices.Main.AddCriticalMessage("No Feedback Reminder loaded.");
#if DEBUG
            Logger.Log("No Feedback Reminder loaded.");
#endif
            Harmony harmony = new Harmony("com.yw2theorycrafter.nofeedbackreminder");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
