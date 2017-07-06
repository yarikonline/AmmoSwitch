using Microsoft.Xna.Framework;

using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using Terraria;
using Microsoft.Xna.Framework.Graphics;

namespace AmmoSwitcher
{
    class ASUI : UIState
    {

        public static bool visible = false;

        public UIPanel slot1;
        public UIPanel slot2;
        public UIPanel slot3;
        public UIPanel slot4;

        public override void OnInitialize()
        {
            UIPanel parent = new UIPanel();
            parent.Height.Set(60f, 0f);
            parent.Width.Set(159f, 0f);
            parent.Left.Set(512f, 0f);
            parent.Top.Set(7f, 0f);
            parent.SetPadding(0f);
            parent.BackgroundColor = new Color(0f, 0f, 0f, 0f);
            parent.BorderColor = new Color(0f, 0f, 0f, 0f);

            UIText head = new UIText("Ammo", 0.9f);
            head.HAlign = UIAlign.Center;
            parent.Append(head);

            slot1 = new UIPanel();
            slot1.Height.Set(35f, 0f);
            slot1.Width.Set(35f, 0f);
            slot1.Left.Set(5f, 0f);
            slot1.Top.Set(17f, 0f);
            slot1.BorderColor = new Color(200, 200, 50);
            parent.Append(slot1);
            
            slot2 = new UIPanel();
            slot2.Height.Set(35f, 0f);
            slot2.Width.Set(35f, 0f);
            slot2.Left.Set(43f, 0f);
            slot2.Top.Set(17f, 0f);
            slot2.BorderColor = new Color(0, 0, 0, 150);
            parent.Append(slot2);

            slot3 = new UIPanel();
            slot3.Height.Set(35f, 0f);
            slot3.Width.Set(35f, 0f);
            slot3.Left.Set(81f, 0f);
            slot3.Top.Set(17f, 0f);
            slot3.BorderColor = new Color(0, 0, 0, 150);
            parent.Append(slot3);

            slot4 = new UIPanel();
            slot4.Height.Set(35f, 0f);
            slot4.Width.Set(35f, 0f);
            slot4.Left.Set(119f, 0f);
            slot4.Top.Set(17f, 0f);
            slot4.BorderColor = new Color(0, 0, 0, 150);
            parent.Append(slot4);

            Append(parent);

            //UIImage img = new UIImage()
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

    }
}
