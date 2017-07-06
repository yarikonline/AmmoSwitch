using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using Terraria.ID;
using Terraria;

namespace AmmoSwitcher.UI
{
    class ASUI : UIState
    {

        public static bool visible = false;
        public static int activeSlot = 54;
        private Color defColor;
        private Color useColor = new Color(200, 200, 50, 200);
        private Player player;

        private UIPanel slot1;
        private UIPanel slot2;
        private UIPanel slot3;
        private UIPanel slot4;

        private UIImage ammo1;
        private UIImage ammo2;
        private UIImage ammo3;
        private UIImage ammo4;

        private UIText head;
        private UIText text1;
        private UIText text2;
        private UIText text3;
        private UIText text4;
        private UIText info;

        public override void OnInitialize()
        {
            player = Main.player[Main.myPlayer];

            UIPanel parent = new UIPanel();
            defColor = parent.BackgroundColor;
            parent.Height.Set(60f, 0f);
            parent.Width.Set(159f, 0f);
            parent.Left.Set(500f, 0f);
            parent.Top.Set(7f, 0f);
            parent.SetPadding(0f);
            parent.BackgroundColor = new Color(0f, 0f, 0f, 0f);
            parent.BorderColor = new Color(0f, 0f, 0f, 0f);
            Append(parent);

            head = new UIText("Ammo", 0.9f);
            head.HAlign = UIAlign.Center;
            parent.Append(head);

            slot1 = new UIPanel();
            slot1.Height.Set(35f, 0f);
            slot1.Width.Set(35f, 0f);
            slot1.Left.Set(5f, 0f);
            slot1.Top.Set(17f, 0f);
            slot1.SetPadding(1f);
            slot1.BorderColor = new Color(0, 0, 0, 150);
            parent.Append(slot1);

            ammo1 = new UIImage(Main.itemTexture[getItemInSlot(54).type]);
            ammo1.HAlign = UIAlign.Center;
            ammo1.VAlign = UIAlign.Center;
            ammo1.ImageScale = 0.7f;
            slot1.Append(ammo1);

            text1 = new UIText("0", 0.6f);
            text1.HAlign = UIAlign.Right;
            text1.VAlign = UIAlign.Bottom;
            slot1.Append(text1);
            
            slot2 = new UIPanel();
            slot2.Height.Set(35f, 0f);
            slot2.Width.Set(35f, 0f);
            slot2.Left.Set(43f, 0f);
            slot2.Top.Set(17f, 0f);
            slot2.SetPadding(1f);
            slot2.BorderColor = new Color(0, 0, 0, 150);
            parent.Append(slot2);

            ammo2 = new UIImage(Main.itemTexture[getItemInSlot(55).type]);
            ammo2.HAlign = UIAlign.Center;
            ammo2.VAlign = UIAlign.Center;
            ammo2.ImageScale = 0.7f;
            slot2.Append(ammo2);

            text2 = new UIText("0", 0.6f);
            text2.HAlign = UIAlign.Right;
            text2.VAlign = UIAlign.Bottom;
            slot2.Append(text2);

            slot3 = new UIPanel();
            slot3.Height.Set(35f, 0f);
            slot3.Width.Set(35f, 0f);
            slot3.Left.Set(81f, 0f);
            slot3.Top.Set(17f, 0f);
            slot3.SetPadding(1f);
            slot3.BorderColor = new Color(0, 0, 0, 150);
            parent.Append(slot3);

            ammo3 = new UIImage(Main.itemTexture[getItemInSlot(56).type]);
            ammo3.HAlign = UIAlign.Center;
            ammo3.VAlign = UIAlign.Center;
            ammo3.ImageScale = 0.7f;
            slot3.Append(ammo3);

            text3 = new UIText("0", 0.6f);
            text3.HAlign = UIAlign.Right;
            text3.VAlign = UIAlign.Bottom;
            slot3.Append(text3);

            slot4 = new UIPanel();
            slot4.Height.Set(35f, 0f);
            slot4.Width.Set(35f, 0f);
            slot4.Left.Set(119f, 0f);
            slot4.Top.Set(17f, 0f);
            slot4.SetPadding(1f);
            slot4.BorderColor = new Color(0, 0, 0, 150);
            parent.Append(slot4);

            ammo4 = new UIImage(Main.itemTexture[getItemInSlot(57).type]);
            ammo4.HAlign = UIAlign.Center;
            ammo4.VAlign = UIAlign.Center;
            ammo4.ImageScale = 0.7f;
            slot4.Append(ammo4);

            text4 = new UIText("0", 0.6f);
            text4.HAlign = UIAlign.Right;
            text4.VAlign = UIAlign.Bottom;
            slot4.Append(text4);

            info = new UIText("text!!!");
            Append(info);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            player = Main.player[Main.myPlayer];
            head.TextColor = Colors.AlphaDarken(Color.White);
            // change bgcolor of selected slot
            slot1.BackgroundColor = defColor;
            slot2.BackgroundColor = defColor;
            slot3.BackgroundColor = defColor;
            slot4.BackgroundColor = defColor;
            switch (activeSlot) {
                case 54: slot1.BackgroundColor = useColor; break;
                case 55: slot2.BackgroundColor = useColor; break;
                case 56: slot3.BackgroundColor = useColor; break;
                case 57: slot4.BackgroundColor = useColor; break;
            }
            // add ammo image
            ammo1.SetImage(Main.itemTexture[getItemInSlot(54).type]);
            ammo2.SetImage(Main.itemTexture[getItemInSlot(55).type]);
            ammo3.SetImage(Main.itemTexture[getItemInSlot(56).type]);
            ammo4.SetImage(Main.itemTexture[getItemInSlot(57).type]);
            // add ammo count
            int[] count = { 0, 0, 0, 0 } ;
            foreach (Item item in player.inventory)
            {
                if (item.type == getItemInSlot(54).type) count[0] += item.stack;
                if (item.type == getItemInSlot(55).type) count[1] += item.stack;
                if (item.type == getItemInSlot(56).type) count[2] += item.stack;
                if (item.type == getItemInSlot(57).type) count[3] += item.stack;
            }
            text1.SetText((count[0] > 0) ? count[0].ToString() : "");
            text2.SetText((count[1] > 0) ? count[1].ToString() : "");
            text3.SetText((count[2] > 0) ? count[2].ToString() : "");
            text4.SetText((count[3] > 0) ? count[3].ToString() : "");
            // set ammo text on hovering
            if (slot1.IsMouseHovering)
            {
                info.SetText(getItemInSlot(54).Name + " (" + text1.Text + ")");
                info.TextColor = Colors.AlphaDarken(getRarityColor(getItemInSlot(54).rare));
            }
            else if (slot2.IsMouseHovering)
            {
                info.SetText(getItemInSlot(55).Name + " (" + text2.Text + ")");
                info.TextColor = Colors.AlphaDarken(getRarityColor(getItemInSlot(55).rare));
            }
            else if (slot3.IsMouseHovering)
            {
                info.SetText(getItemInSlot(56).Name + " (" + text3.Text + ")");
                info.TextColor = Colors.AlphaDarken(getRarityColor(getItemInSlot(56).rare));
            }
            else if (slot4.IsMouseHovering)
            {
                info.SetText(getItemInSlot(57).Name + " (" + text4.Text + ")");
                info.TextColor = Colors.AlphaDarken(getRarityColor(getItemInSlot(57).rare));
            }
            else info.SetText("");
            info.Left.Set(Main.mouseX + 20, 0);
            info.Top.Set(Main.mouseY + 20, 0);

            // update graphics
            RecalculateChildren();
            base.Draw(spriteBatch);
        }

        // a little shortcut
        private Item getItemInSlot(int ammoslot)
        {
            return player.inventory[ammoslot];
        }
        
        private Color getRarityColor(int rare) { 
            switch (rare)
            {
                case -1: return Colors.RarityTrash; break;
                case 0: return Colors.RarityNormal; break;
                case 1: return Colors.RarityBlue; break;
                case 2: return Colors.RarityGreen; break;
                case 3: return Colors.RarityOrange; break;
                case 4: return new Color(244, 144, 144); break;
                case 5: return Colors.RarityPink; break;
                case 6: return new Color(190, 144, 229); break;
                case 7: return Colors.RarityLime; break;
                case 8: return Colors.RarityYellow; break;
                case 9: return Colors.RarityCyan; break;
                case 10: return Colors.RarityRed; break;
                case 11: return Colors.RarityPurple; break;
                default: return Color.White;
            }
        }

    }
}
