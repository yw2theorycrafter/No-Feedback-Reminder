using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using HarmonyLib;

namespace No_Feedback_Reminder.Patches
{
    [HarmonyPatch]
    public class FeedbackCollector_Awake_Patch
    {
#pragma warning disable IDE0051 // Remove unused private members
        static MethodBase TargetMethod()
        {
            //Awake is a protected method, so we have to set the BindingFlags accordingly.
            return typeof(uGUI_FeedbackCollector).GetMethod(
                "Awake",
                BindingFlags.Instance | BindingFlags.NonPublic);
        }
#pragma warning disable IDE0051 // Remove unused private members
        static void Postfix(MethodBase __originalMethod, uGUI_FeedbackCollector __instance)
        {
#if DEBUG
            Logger.Log("Patching GUI element " + __instance.ToString() + " with " + __originalMethod.ToString());
#endif
            var couldFind = false;
            foreach (UnityEngine.Transform child in __instance.transform)
            {
                if (child.name.Equals("FeedbackHint"))
                {
                    child.gameObject.SetActive(false);
                    couldFind = true;
#if DEBUG
                    Logger.Log("Successfully disabled " + child.ToString() + " of GUI element " + __instance.ToString());
#endif
                    goto searchEnd;
                }
            }
        searchEnd: if (!couldFind)
            {
                Logger.Log("WARN: Couldn't find FeedbackHint child of GUI element " + __instance.ToString());
            }
        }
    }
}
