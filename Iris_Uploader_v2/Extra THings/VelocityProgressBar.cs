using System;
using System.Drawing;
using System.Windows.Forms;

// Token: 0x0200000B RID: 11
public class VelocityProgressBar : Control
{
	// Token: 0x17000013 RID: 19
	// (get) Token: 0x06000059 RID: 89 RVA: 0x00003720 File Offset: 0x00001920
	// (set) Token: 0x0600005A RID: 90 RVA: 0x00003738 File Offset: 0x00001938
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

	// Token: 0x17000014 RID: 20
	// (get) Token: 0x0600005B RID: 91 RVA: 0x0000374C File Offset: 0x0000194C
	// (set) Token: 0x0600005C RID: 92 RVA: 0x00003764 File Offset: 0x00001964
	public Color ProgressColor
	{
		get
		{
			return this._progressColor;
		}
		set
		{
			this._progressColor = value;
			base.Invalidate();
		}
	}

	// Token: 0x17000015 RID: 21
	// (get) Token: 0x0600005D RID: 93 RVA: 0x00003778 File Offset: 0x00001978
	// (set) Token: 0x0600005E RID: 94 RVA: 0x00003790 File Offset: 0x00001990
	public int Value
	{
		get
		{
			return this._val;
		}
		set
		{
			this._val = value;
			this.ValChanged();
			base.Invalidate();
		}
	}

	// Token: 0x17000016 RID: 22
	// (get) Token: 0x0600005F RID: 95 RVA: 0x000037A8 File Offset: 0x000019A8
	// (set) Token: 0x06000060 RID: 96 RVA: 0x000037C0 File Offset: 0x000019C0
	public int Min
	{
		get
		{
			return this._min;
		}
		set
		{
			this._min = value;
			base.Invalidate();
		}
	}

	// Token: 0x17000017 RID: 23
	// (get) Token: 0x06000061 RID: 97 RVA: 0x000037D4 File Offset: 0x000019D4
	// (set) Token: 0x06000062 RID: 98 RVA: 0x000037EC File Offset: 0x000019EC
	public int Max
	{
		get
		{
			return this._max;
		}
		set
		{
			this._max = value;
			base.Invalidate();
		}
	}

	// Token: 0x17000018 RID: 24
	// (get) Token: 0x06000063 RID: 99 RVA: 0x00003800 File Offset: 0x00001A00
	// (set) Token: 0x06000064 RID: 100 RVA: 0x00003818 File Offset: 0x00001A18
	public bool ShowPercent
	{
		get
		{
			return this._showPercent;
		}
		set
		{
			this._showPercent = value;
			base.Invalidate();
		}
	}

	// Token: 0x06000065 RID: 101 RVA: 0x0000382C File Offset: 0x00001A2C
	private void ValChanged()
	{
		bool flag = this._val > this._max;
		if (flag)
		{
			this._val = this._max;
		}
	}

	// Token: 0x06000066 RID: 102 RVA: 0x0000385C File Offset: 0x00001A5C
	public VelocityProgressBar()
	{
		this.DoubleBuffered = true;
	}

	// Token: 0x06000067 RID: 103 RVA: 0x000038B8 File Offset: 0x00001AB8
	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		Graphics graphics = e.Graphics;
		bool showPercent = this._showPercent;
		if (showPercent)
		{
			graphics.FillRectangle(new SolidBrush(Helpers.FromHex("#506070")), 0, 0, base.Width - 35, base.Height - 1);
			graphics.FillRectangle(new SolidBrush(this._progressColor), new Rectangle(0, 0, this._val * (base.Width - 35) / (this._max - this._min), base.Height));
			graphics.DrawRectangle(new Pen(Color.Black), 0, 0, base.Width - 35, base.Height - 1);
			graphics.DrawString(this._val + "%", this.Font, new SolidBrush(this.ForeColor), (float)(base.Width - 30), (float)(base.Height / 2) - graphics.MeasureString(this._val + "%", this.Font).Height / 2f - 1f);
		}
		else
		{
			graphics.Clear(Helpers.FromHex("#506070"));
			graphics.FillRectangle(new SolidBrush(this._progressColor), new Rectangle(0, 0, this._val * base.Width / (this._max - this._min), base.Height));
			graphics.DrawRectangle(new Pen(Color.Black), 0, 0, base.Width - 1, base.Height - 1);
		}
	}

	// Token: 0x0400001C RID: 28
	private Color _border = Helpers.FromHex("#485e75");

	// Token: 0x0400001D RID: 29
	private Color _progressColor = Helpers.FromHex("#2c3e50");

	// Token: 0x0400001E RID: 30
	private int _val = 0;

	// Token: 0x0400001F RID: 31
	private int _min = 0;

	// Token: 0x04000020 RID: 32
	private int _max = 100;

	// Token: 0x04000021 RID: 33
	private bool _showPercent = false;
}
