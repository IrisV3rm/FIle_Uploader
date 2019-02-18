using System;
using System.Drawing;
using System.Windows.Forms;

// Token: 0x02000007 RID: 7
public class VelocitySplitter : Control
{
	// Token: 0x1700000A RID: 10
	// (get) Token: 0x06000038 RID: 56 RVA: 0x00002D00 File Offset: 0x00000F00
	// (set) Token: 0x06000039 RID: 57 RVA: 0x00002D18 File Offset: 0x00000F18
	public int Offset
	{
		get
		{
			return this._offset;
		}
		set
		{
			this._offset = value;
			base.Invalidate();
		}
	}

	// Token: 0x0600003A RID: 58 RVA: 0x00002D29 File Offset: 0x00000F29
	public VelocitySplitter()
	{
		this.DoubleBuffered = true;
	}

	// Token: 0x0600003B RID: 59 RVA: 0x00002D44 File Offset: 0x00000F44
	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		Graphics graphics = e.Graphics;
		graphics.DrawLine(new Pen(this.ForeColor), new Point(this._offset, base.Height / 2 - 2), new Point(base.Width - this._offset, base.Height / 2 - 1));
	}

	// Token: 0x0400000F RID: 15
	private int _offset = 8;
}
