using FungleAPI.Base.Buttons;
using FungleAPI.Utilities;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownOfTrailay.Roles.Impostors;
using TownOfTrailay.TotUtilities;
using UnityEngine;

namespace TownOfTrailay.Buttons.ImpostorButtons
{
    public class VampireBite : RoleTargetButton<PlayerControl, VampireRole>
    {
        public override string OverrideText => TotTranslation.VampireBite.GetString();
        public override Color32 TextOutlineColor => TotPalette.VampireColor;
        public override float Cooldown => VampireRole.BiteCooldown;
        public override Sprite ButtonSprite => HudManager.Instance.KillButton.graphic.sprite;

        public override void SetOutline(PlayerControl target, bool active)
        {
            target?.cosmetics?.SetOutline(active, new Il2CppSystem.Nullable<Color>(TextOutlineColor));
        }
        public override PlayerControl GetTarget()
        {
            return PlayerControl.LocalPlayer.Data.Role.FindClosestTarget();
        }

        public override void OnClick()
        {
            if (Target == null) return;
            VampireRole vampireRole = PlayerControl.LocalPlayer.Data.Role.SafeCast<VampireRole>();
            if (vampireRole != null)
            {
                vampireRole.Murders[Target] = new ChangeableValue<float>(VampireRole.MurderDelay);
            }
        }
    }
}
