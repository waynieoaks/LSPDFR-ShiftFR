using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using LSPD_First_Response;
using LSPD_First_Response.Mod.API;
using LSPD_First_Response.Mod.Callouts;
using LSPD_First_Response.Engine.Scripting.Entities;


namespace ShiftFR
{
    public class EntryPoint : Plugin
    {
        //Initialization of the plugin.
        public override void Initialize()
        {
            //This is saying that when our OnDuty status is changed, it calls for the code to call private static void OnOnDutyStateChangedHandler near the bottom of this page.
            Functions.OnOnDutyStateChanged += OnOnDutyStateChangedHandler;

            //Game.LogTrivial's are used to help you identify problems when debugging a crash with your plugin, so you know exactly what's going on when.

            //This will show in the RagePluginHook.log as "Example Plugin 1.0.0.0 has been initialised." 
            Game.LogTrivial("ShiftFR " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + " has been initialised.");

            //This one will show in RagePluginHook.log as "Go on duty to fully load Example Plugin."
            Game.LogTrivial("ShiftFR will start logging hours when you go on duty.");
        }
        //This is a simple message saying that Example Plugin has been cleanup.
        public override void Finally()
        {
            Game.LogTrivial("ShiftFR has been cleaned up.");
        }
        //This is called by Functions.OnOnDutyStateChanged as stated above, but only when bool OnDuty is true.
        private static void OnOnDutyStateChangedHandler(bool OnDuty)
        {
            //We have to make sure they are actually on duty so the code can do its work, so we use an "if" statement.
            if (OnDuty)
            {

                //This shows a notification at the bottom left, above the minimap, of your screen when you go on duty, stating exactly what's in the quotation marks.
                Game.DisplayNotification("ShiftFR " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + " has loaded successfully!");
            }
        }
        //This is the method that we called earlier in private static void OnOnDutyStateChangedHandler. This registers the callouts we have it setup to register, we'll come back to this after we make our callout.

    }
}
