using Terraria.ModLoader;
using Terraria.UI;
using Terraria;

namespace AmmoSwitcher
{
    class ASUI : UIState
    {

        public static bool visible = false;

        public override void OnInitialize()
        {
            UIElement parent = new UIElement();
            parent.Height.Set(150f, 0f);
            parent.Width.Set(150f, 0f);
            parent.Left.Set(Main.screenWidth / 2f, 0f);
            parent.Top.Set(20f, 0f);
            parent.Id = "tst";

            base.Append(parent);
        }

        public override void Click(UIMouseEvent evt)
        {
            if (evt.Target.Id == "tst") Main.NewText("yes, it is");
        }

    }
}
