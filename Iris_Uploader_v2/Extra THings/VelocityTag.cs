using System;
using System.Drawing;
using System.Windows.Forms;

// Token: 0x0200000A RID: 10
public class VelocityTag : Control
{
	// Token: 0x17000012 RID: 18
	// (get) Token: 0x06000054 RID: 84 RVA: 0x0000361C File Offset: 0x0000181C
	// (set) Token: 0x06000055 RID: 85 RVA: 0x00003634 File Offset: 0x00001834
	public Color Border
	{
		get
		{
			return this._border;
		}
		set
		{
			this._border = value;
			base.Invalidate();
		}
	}

	// Token: 0x06000056 RID: 86 RVA: 0x00003645 File Offset: 0x00001845
	public VelocityTag()
	{
		this.DoubleBuffered = true;
		this.BackColor = Helpers.FromHex("#34495e");
		this.ForeColor = Color.White;
	}

	// Token: 0x06000057 RID: 87 RVA: 0x00003684 File Offset: 0x00001884
	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		Graphics graphics = e.Graphics;
		graphics.Clear(this.BackColor);
		graphics.DrawRectangle(new Pen(this._border), 0, 0, base.Width - 1, base.Height - 1);
		graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), new Rectangle(0, 0, base.Width, base.Height), new StringFormat
		{
			Alignment = StringAlignment.Center,
			LineAlignment = StringAlignment.Center
		});
	}

	// Token: 0x06000058 RID: 88 RVA: 0x00002416 File Offset: 0x00000616
	protected override void OnTextChanged(EventArgs e)
	{
		base.OnTextChanged(e);
		base.Invalidate();
	}

	// Token: 0x0400001B RID: 27
	private Color _border = Helpers.FromHex("#2c3e50");
}
