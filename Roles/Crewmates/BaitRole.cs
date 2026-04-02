using FungleAPI.Base.Roles;
using FungleAPI.Role;
using FungleAPI.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownOfTrailay.TotUtilities;
using UnityEngine;

namespace TownOfTrailay.Roles.Crewmates
{
    public class BaitRole : CrewmateBase, ICustomRole
    {
        public ModdedTeam Team => ModdedTeamManager.Crewmates;
        public StringNames RoleName => TotTranslation.BaitName;
        public StringNames RoleBlur => TotTranslation.BaitBlur;
        public StringNames RoleBlurMed => TotTranslation.BaitBlur;
        public Color RoleColor { get; } = new Color32(64, 141, 145, byte.MaxValue);
    }
}
