using FungleAPI.Freeplay;
using FungleAPI.Freeplay.Helpers;
using FungleAPI.PluginLoading;
using FungleAPI.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static FilterPopUp.FilterInfoUI;

namespace TownOfTrailay.TotUtilities
{
    public class TotFreeplayFolder : ModFolderConfig
    {
        public override string FolderName => "<size=80%>TownOfTrailay\nFungleAPI";
        public Folder RoleFolder;
        public override void Initialize(ModPlugin modPlugin)
        {
            base.Initialize(modPlugin);
            if (RoleFolder == null)
            {
                RoleFolder = new Folder()
                {
                    FolderName = "Dummy Debug",
                    FolderColor = Color.blue
                };
                SubFolders.Add(RoleFolder);
            }
            RoleFolder.SubFolders.Clear();
            foreach (PlayerControl playerControl in PlayerControl.AllPlayerControls)
            {
                if (!playerControl.AmOwner)
                {
                    Folder playerRoleFolder = new Folder()
                    {
                        FolderName = playerControl.Data.PlayerName,
                        FolderColor = playerControl.Data.Color
                    };
                    foreach (RoleBehaviour roleBehaviour in CustomRoleManager.AllRoles)
                    {
                        if (roleBehaviour.CustomRole() == null && RoleManager.IsGhostRole(roleBehaviour.Role) || roleBehaviour.CustomRole() != null && roleBehaviour.CustomRole().HideInFreeplayComputer)
                        {
                            continue;
                        }
                        playerRoleFolder.Items.Add(new FolderItem()
                        {
                            Name = "Set_" + roleBehaviour.NiceName + ".exe",
                            Color = roleBehaviour.TeamColor,
                            OnClick = delegate
                            {
                                playerControl?.RpcSetRole(roleBehaviour.Role);
                            },
                            Overlay = () => playerControl.Data.RoleType == roleBehaviour.Role
                        });
                    }
                    RoleFolder.SubFolders.Add(playerRoleFolder);
                }
            }
        }
    }
}
