using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.GameInput;
using Terraria.ModLoader;

using AmmoSwitcher.UI;

namespace AmmoSwitcher
{
    class ASPlayer : ModPlayer
    {
        public int useAmmoSlot = 54; //ammo slots are 54 - 57 inventory slots (top to bottom)

        // switching slot and displaying message
        public override void ProcessTriggers(TriggersSet triggersSet)
        {            
            if (AmmoSwitcher.useAmmo1.JustPressed)
            {
                useAmmoSlot = 54;
                if (ASUI.visible) Main.PlaySound(SoundID.MenuTick);
            }

            if (AmmoSwitcher.useAmmo2.JustPressed)
            {
                useAmmoSlot = 55;
                if (ASUI.visible) Main.PlaySound(SoundID.MenuTick);
            }

            if (AmmoSwitcher.useAmmo3.JustPressed)
            {
                useAmmoSlot = 56;
                if (ASUI.visible) Main.PlaySound(SoundID.MenuTick);
            }

            if (AmmoSwitcher.useAmmo4.JustPressed)
            {
                useAmmoSlot = 57;
                if (ASUI.visible) Main.PlaySound(SoundID.MenuTick);
            }
            
            ASUI.activeSlot = useAmmoSlot;
            if (player.HeldItem.useAmmo > 0 && !Main.playerInventory) ASUI.visible = true;
            else ASUI.visible = false;
        }
        
        // consuming right item, priority to topleft corner of inventory
        public override bool ConsumeAmmo(Item weapon, Item ammo)
        {
            // target ammo to consume
            Item usedAmmo = player.inventory[useAmmoSlot]; 

            // if selected ammo can't be used with current weapon
            if (usedAmmo.ammo != weapon.useAmmo)
                for (int i = 54; ; i++) // even if consuming priority is topleft, search of projectile started at ammo slots, like in vanilla
                {
                    if (i == player.inventory.Length) i = 0;
                    if (player.inventory[i].ammo == weapon.useAmmo)
                    {
                        usedAmmo = player.inventory[i];
                        break;
                    }
                    if (i == 53) break;
                }

            // endles munition
            if (usedAmmo.type == ItemID.EndlessMusketPouch) return false;
            if (usedAmmo.type == ItemID.EndlessQuiver) return false;

            // checking buffs
            if (player.ammoCost80)
            {
                if (Main.rand.Next(100) < 20) return false;
            }
            else if (player.ammoCost75)
            {
                if (Main.rand.Next(100) < 25) return false;
            }
            else if (player.ammoBox)
            {
                if (Main.rand.Next(100) < 20) return false;
            }
            else if (player.ammoPotion)
            {
                if (Main.rand.Next(100) < 20) return false;
            }
            else if (player.magicQuiver && usedAmmo.ammo == AmmoID.Arrow)
            {
                if (Main.rand.Next(100) < 20) return false;
            }

            // checking weapon // dunno, maybe there is better way
            if (weapon.type == ItemID.BoneGlove)
                if (Main.rand.Next(100) < 33) return false;
            if (weapon.type == ItemID.Minishark)
                if (Main.rand.Next(100) < 33) return false;
            if (weapon.type == ItemID.Megashark)
                if (Main.rand.Next(100) < 50) return false;
            if (weapon.type == ItemID.Gatligator)
                if (Main.rand.Next(100) < 50) return false;
            if (weapon.type == ItemID.ChainGun)
                if (Main.rand.Next(100) < 50) return false;
            if (weapon.type == ItemID.SDMG)
                if (Main.rand.Next(100) < 50) return false;
            if (weapon.type == ItemID.CandyCornRifle)
                if (Main.rand.Next(100) < 33) return false;
            // flamethrowers work a bit different, but this is an easier way and gives almost same result
            if (weapon.type == ItemID.Flamethrower)
                if (Main.rand.Next(100) < 80) return false;
            if (weapon.type == ItemID.EldMelter)
                if (Main.rand.Next(100) < 80) return false;

            // consume... finally
            player.ConsumeItem(usedAmmo.type);
            return false;
            
        }
              
         
    }
}
