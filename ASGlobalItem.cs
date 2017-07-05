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
            
            // change projectule type to selected
            if (selectedAmmo.ammo == player.HeldItem.useAmmo && selectedAmmo != item)
            {
                type = selectedAmmo.shoot;
            }
        }

    }
}
