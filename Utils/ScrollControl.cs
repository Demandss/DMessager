using System;
using System.Drawing;
using System.Windows.Forms;

namespace DMessager.Utils
{
    public class ScrollControl : ScrollableControl 
    {
        public ScrollControl()
        {
            VScroll = false;
            HScroll = false;
        }

        /*protected override void OnMouseWheel(MouseEventArgs args)
        {
            base.OnMouseWheel(args);
            int change = VerticalScroll.Value - args.Delta / 10;
            change = Math.Max(change, VerticalScroll.Minimum);
            change = Math.Min(change, VerticalScroll.Maximum);
            VerticalScroll.Value = change;
        }*/
    }
}