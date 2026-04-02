using FungleAPI.Base.Roles;
using FungleAPI.Configuration.Attributes;
using FungleAPI.Role;
using FungleAPI.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FungleAPI.Attributes;
using TownOfTrailay.TotUtilities;
using UnityEngine;
using FungleAPI.Player;
using FungleAPI.Utilities;

namespace TownOfTrailay.Roles.Impostors
{
    public class VampireRole : ImpostorBase, ICustomRole
    {
        [TranslationHelper("vampire_bitecooldown")] // Set a translated Option Name
        [ModdedNumberOption(null, 5, 60)]
        public static float BiteCooldown => 20;
        [TranslationHelper("vampire_murderdelay")] // Set a translated Option Name
        [ModdedNumberOption(null, 2, 20)]
        public static float MurderDelay => 7;

        public Dictionary<PlayerControl, ChangeableValue<float>> Murders = new Dictionary<PlayerControl, ChangeableValue<float>>();

        public ModdedTeam Team => ModdedTeamManager.Impostors;
        public StringNames RoleName => TotTranslation.VampireName;
        public StringNames RoleBlur => TotTranslation.VampireBlur;
        public StringNames RoleBlurMed => TotTranslation.VampireBlur;
        public Color RoleColor { get; } = TotPalette.VampireColor;
        public bool CanKill => true;
        public bool UseVanillaKillButton => false;

        public override bool ValidTarget(NetworkedPlayerInfo target)
        {
            return base.ValidTarget(target) && !Murders.ContainsKey(target.Object);
        }
        public void Update()
        {
            if (Player == null || !Player.AmOwner || Murders.Count <= 0) return;
            for (int i = Murders.Count - 1; i >= 0; i--)
            {
                KeyValuePair<PlayerControl, ChangeableValue<float>> timedMurder = Murders.ElementAt(i);
                timedMurder.Value.Value -= Time.deltaTime;
                if (timedMurder.Value.Value <= 0 || timedMurder.Key == null || timedMurder.Key.Data.IsDead)
                {
                    Player.CmdCheckCustomMurder(timedMurder.Key, false, true, false);
                    Murders.Remove(timedMurder.Key);
                }
            }
        }
    }
}
