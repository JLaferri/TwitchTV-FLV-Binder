using System.Drawing;
using System.Diagnostics;

namespace System.Windows.Forms
{

    /// <summary>
    /// An extension of the ListBox class that is near flicker-free and has a highlighted index.
    /// </summary>
    /// <remarks>Overrides the OnPaint event of a listbox because the one provided is very
    /// prone to flickering. The HighlightedIndex allows for specifying an additional index
    /// which can be used however needed.</remarks>
    internal class JListBox : System.Windows.Forms.ListBox
    {
        protected int _HighlightedIndex;
        public int HighlightedIndex { get { return _HighlightedIndex; } set { _HighlightedIndex = value; } }

        public JListBox()
        {
            _HighlightedIndex = -1;

            this.SetStyle(
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.UserPaint,
                true);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Region iRegion = new Region(e.ClipRectangle);
            e.Graphics.FillRegion(new SolidBrush(this.BackColor), iRegion);
            if (this.Items.Count > 0)
            {
                Debug.WriteLine("Hello");
                for (int i = 0; i < this.Items.Count; ++i)
                {
                    System.Drawing.Rectangle irect = this.GetItemRectangle(i);
                    if (e.ClipRectangle.IntersectsWith(irect))
                    {
                        if ((this.SelectionMode == SelectionMode.One && this.SelectedIndex == i)
                        || (this.SelectionMode == SelectionMode.MultiSimple && this.SelectedIndices.Contains(i))
                        || (this.SelectionMode == SelectionMode.MultiExtended && this.SelectedIndices.Contains(i)))
                        {
                            OnDrawItem(new DrawItemEventArgs(e.Graphics, this.Font,
                                irect, i, DrawItemState.Selected, this.ForeColor,
                                this.BackColor));
                        }
                        else
                        {
                            OnDrawItem(new DrawItemEventArgs(e.Graphics, this.Font,
                                irect, i, DrawItemState.Default, this.ForeColor,
                                this.BackColor));
                        }
                        iRegion.Complement(irect);
                    }
                }
            }
            base.OnPaint(e);
        }
    }
}
