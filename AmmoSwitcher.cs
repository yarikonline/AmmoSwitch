using System.Collections.Generic;

using Terraria.ModLoader;
using Terraria.UI;
using Terraria;

namespace AmmoSwitcher
{
	class AmmoSwitcher : Mod
	{
        // new hotkeys
        public static ModHotKey useAmmo1;
        public static ModHotKey useAmmo2;
        public static ModHotKey useAmmo3;
        public static ModHotKey useAmmo4;

        public UserInterface ammoInfo;

        // TODO: it would be nice to have a litlle UI to see available ammo, w/o opening inventory

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
                ammoInfo = new UserInterface();
            }
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            layers.Add(new GameInterfaceLayer("AmmoSwitcher: Ammo Info", InterfaceScaleType.UI));
        }

    }
}
