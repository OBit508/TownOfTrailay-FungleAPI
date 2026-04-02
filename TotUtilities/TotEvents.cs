using FungleAPI.Components;
using FungleAPI.Event;
using FungleAPI.Event.Vanilla;
using FungleAPI.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownOfTrailay.Roles.Crewmates;
using static UnityEngine.GraphicsBuffer;

namespace TownOfTrailay.TotUtilities
{
    public static class TotEvents
    {
        [EventRegister]
        public static void MurderedEvent(AfterMurderEvent afterMurderEvent)
        {
            if (AmongUsClient.Instance.AmHost && afterMurderEvent.Target != null)
            {
                PlayerHelper playerHelper = afterMurderEvent.Target.GetComponent<PlayerHelper>();
                if (playerHelper.OldRole != null && playerHelper.OldRole.Role == RoleExtensions.GetRoleType<BaitRole>())
                {
                    afterMurderEvent.Source?.ReportDeadBody(afterMurderEvent.Target.Data);
                }
            }
        }
    }
}
