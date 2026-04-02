using FungleAPI.Event;
using FungleAPI.Event.Vanilla;
using FungleAPI.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownOfTrailay.Roles.Crewmates;

namespace TownOfTrailay.TotUtilities
{
    public static class TotEvents
    {
        [EventRegister]
        public static void MurderedEvent(AfterMurderEvent afterMurderEvent)
        {
            if (afterMurderEvent.Target != null && afterMurderEvent.Target.Data.RoleType == RoleExtensions.GetRoleType<BaitRole>())
            {
                afterMurderEvent.Body?.OnClick();
            }
        }
    }
}
