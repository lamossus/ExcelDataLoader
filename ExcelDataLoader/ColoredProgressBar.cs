using System.Drawing.Drawing2D;

namespace ExcelDataLoader
{
    public class ColoredProgressBar : ProgressBar
    {
        public ColoredProgressBar()
        {
            SetStyle(ControlStyles.UserPaint, true);
        }

		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
		}

		protected override void OnPaint(PaintEventArgs e)
        {
            int inset = 2;

            using (Image offscreenImage = new Bitmap(this.Width, this.Height))
            {
                using (Graphics offscreen = Graphics.FromImage(offscreenImage))
                {
                    Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

                    if (ProgressBarRenderer.IsSupported)
                        ProgressBarRenderer.DrawHorizontalBar(offscreen, rect);

                    rect.Inflate(-inset, -inset);
                    rect.Width = (int)(rect.Width * (((double)Value - Minimum) / ((double)Maximum - Minimum)));
                    if (rect.Width != 0)
					{
                        LinearGradientBrush brush = new LinearGradientBrush(rect, this.BackColor, this.ForeColor, LinearGradientMode.Vertical);

                        offscreen.FillRectangle(brush, inset, inset, rect.Width, rect.Height);
                    }
                    e.Graphics.DrawImage(offscreenImage, 0, 0);
                }
            }
        }
    }
}
