using System.Collections.Generic;

using Terraria.ModLoader;
using Terraria.UI;
using Terraria;

using AmmoSwitcher.UI;

namespace AmmoSwitcher
{
	class AmmoSwitcher : Mod
	{
        // new hotkeys
        public static ModHotKey useAmmo1;
        public static ModHotKey useAmmo2;
        public static ModHotKey useAmmo3;
        public static ModHotKey useAmmo4;
        
        public UserInterface ammoUI;
        public ASUI ammoInfo;

		public AmmoSwitcher()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}
        
        public override void Load()
        {
            // registering hotkeys
            useAmmo1 = RegisterHotKey("Ammo Switcher: Use Ammo Slot 1", "F1");
            useAmmo2 = RegisterHotKey("Ammo Switcher: Use Ammo Slot 2", "F2");
            useAmmo3 = RegisterHotKey("Ammo Switcher: Use Ammo Slot 3", "F3");
            useAmmo4 = RegisterHotKey("Ammo Switcher: Use Ammo Slot 4", "F4");

            if (!Main.dedServ)
            {
                ammoUI = new UserInterface();
                ammoInfo = new ASUI();
                ammoUI.SetState(ammoInfo);
            }
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int hotbarLayer = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Hotbar"));
            if (hotbarLayer != -1)
            {
                layers.Insert(hotbarLayer, new LegacyGameInterfaceLayer("AmmoSwitcher: Ammo Info",
                    delegate
                    {
                        if (ASUI.visible)
                        {
                            ammoUI.Update(Main._drawInterfaceGameTime);
                            ammoInfo.Draw(Main.spriteBatch);
                        }
                        return true;
                    }
                    , InterfaceScaleType.UI));
            }
        }
        

    }
}
