using System;
using System.Drawing;
using System.Windows.Forms;

// Token: 0x02000006 RID: 6
public class VelocityTitle : Control
{
	// Token: 0x17000009 RID: 9
	// (get) Token: 0x06000032 RID: 50 RVA: 0x00002A58 File Offset: 0x00000C58
	// (set) Token: 0x06000033 RID: 51 RVA: 0x00002A70 File Offset: 0x00000C70
	public Helpers.TxtAlign TextAlign
	{
		get
		{
			return this._txtAlign;
		}
		set
		{
			this._txtAlign = value;
			base.Invalidate();
		}
	}

	// Token: 0x06000034 RID: 52 RVA: 0x00002A81 File Offset: 0x00000C81
	public VelocityTitle()
	{
		this.DoubleBuffered = true;
		base.Size = new Size(180, 23);
	}

	// Token: 0x06000035 RID: 53 RVA: 0x00002AB0 File Offset: 0x00000CB0
	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		Graphics graphics = e.Graphics;
		graphics.DrawLine(new Pen(Helpers.FromHex("#435363")), new Point(0, base.Height / 2), new Point(base.Width, base.Height / 2));
		Size size = graphics.MeasureString(this.Text, this.Font).ToSize();
		switch (this._txtAlign)
		{
		case Helpers.TxtAlign.Left:
			graphics.FillRectangle(new SolidBrush(this.BackColor), new Rectangle(18, base.Height / 2 - size.Height - 2, size.Width + 6, base.Height / 2 + size.Height / 2 + 6));
			graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), 20f, (float)(base.Height / 2 - size.Height / 2));
			break;
		case Helpers.TxtAlign.Center:
			graphics.FillRectangle(new SolidBrush(this.BackColor), new Rectangle(base.Width / 2 - size.Width / 2 - 2, base.Height / 2 - size.Height / 2 - 2, size.Width + 2, size.Height + 2));
			graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), (float)(base.Width / 2 - size.Width / 2), (float)(base.Height / 2 - size.Height / 2));
			break;
		case Helpers.TxtAlign.Right:
			graphics.FillRectangle(new SolidBrush(this.BackColor), new Rectangle(base.Width - (size.Width + 18), base.Height / 2 - size.Height - 2, size.Width + 4, base.Height + 6));
			graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), (float)(base.Width - (size.Width + 16)), (float)(base.Height / 2 - size.Height / 2));
			break;
		}
	}

	// Token: 0x06000036 RID: 54 RVA: 0x00002CEC File Offset: 0x00000EEC
	protected override void OnFontChanged(EventArgs e)
	{
		base.OnFontChanged(e);
		base.Invalidate();
	}

	// Token: 0x06000037 RID: 55 RVA: 0x00002416 File Offset: 0x00000616
	protected override void OnTextChanged(EventArgs e)
	{
		base.OnTextChanged(e);
		base.Invalidate();
	}

	// Token: 0x0400000E RID: 14
	private Helpers.TxtAlign _txtAlign = Helpers.TxtAlign.Left;
}
