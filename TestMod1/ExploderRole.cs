using MiraAPI.Roles;
using UnityEngine;

namespace TestMod1;

public class ExploderRole : ImpostorRole, ICustomRole
{
    public string RoleName => "Bomber";
    public string RoleLongDescription => "Bomb another player.";
    public string RoleDescription => RoleLongDescription;
    public Color RoleColor => Palette.Orange;
    public ModdedRoleTeams Team => ModdedRoleTeams.Impostor;

    public CustomRoleConfiguration Configuration => new CustomRoleConfiguration(this)
    {
        MaxRoleCount = 15,
        DefaultRoleCount = 1,
        DefaultChance = 80,
        UseVanillaKillButton = false
    };
}