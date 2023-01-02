using HarmonyLib;
using BepInEx;
using System.Reflection;

namespace No_Feedback_Reminder
{
    [BepInPlugin("com.zemogiter.nofeedbackreminder", "NoFeedbackReminder", "1.0.0.0")]
    public class MyPlugin : BaseUnityPlugin
    {
        private void Start()
        {
            var harmony = new Harmony("com.zemogiter.nofeedbackreminder");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
