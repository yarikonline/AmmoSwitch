using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace AmmoSwitcher
{
    class ASGlobalItem : GlobalItem
    {

        // this changes type of projectile fired... easy
        public override void PickAmmo(Item item, Player player, ref int type, ref float speed, ref int damage, ref float knockback)
        {
            Item selectedAmmo = player.inventory[player.GetModPlayer<AmmoSwitcherPlayer>(mod).useAmmoSlot];
            // some ammo have different projectile, then fired from weapon, this must be preserved
            

            // change projectule type to selected
            if (selectedAmmo.ammo == item.ammo && player.HeldItem.shoot == 0)
            {
                type = player.inventory[player.GetModPlayer<AmmoSwitcherPlayer>(mod).useAmmoSlot].shoot;
            }
        }

    }
}
