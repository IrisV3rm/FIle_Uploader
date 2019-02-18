using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

// Token: 0x02000004 RID: 4
[DefaultEvent("CheckChanged")]
public class VelocityCheckBox : Control
{
	// Token: 0x14000001 RID: 1
	// (add) Token: 0x06000014 RID: 20 RVA: 0x00002428 File Offset: 0x00000628
	// (remove) Token: 0x06000015 RID: 21 RVA: 0x00002460 File Offset: 0x00000660
	public event VelocityCheckBox.CheckChangedEventHandler CheckChanged;

	// Token: 0x17000005 RID: 5
	// (get) Token: 0x06000016 RID: 22 RVA: 0x00002498 File Offset: 0x00000698
	// (set) Token: 0x06000017 RID: 23 RVA: 0x000024B0 File Offset: 0x000006B0
	public override bool AutoSize
	{
		get
		{
			return this._autoSize;
		}
		set
		{
			this._autoSize = value;
			base.Invalidate();
		}
	}

	// Token: 0x17000006 RID: 6
	// (get) Token: 0x06000018 RID: 24 RVA: 0x000024C4 File Offset: 0x000006C4
	// (set) Token: 0x06000019 RID: 25 RVA: 0x000024DC File Offset: 0x000006DC
	public bool Checked
	{
		get
		{
			return this._checked;
		}
		set
		{
			this._checked = value;
			base.Invalidate();
		}
	}

	// Token: 0x0600001A RID: 26 RVA: 0x000024ED File Offset: 0x000006ED
	public VelocityCheckBox()
	{
		this.DoubleBuffered = true;
	}

	// Token: 0x0600001B RID: 27 RVA: 0x00002514 File Offset: 0x00000714
	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		bool autoSize = this.AutoSize;
		if (autoSize)
		{
			base.Size = new Size(TextRenderer.MeasureText(this.Text, this.Font).Width + 28, base.Height);
		}
		Graphics graphics = e.Graphics;
		Helpers.MouseState state = this._state;
		if (state != Helpers.MouseState.Hover)
		{
			graphics.FillRectangle(Brushes.White, 4, 4, 14, 14);
		}
		else
		{
			graphics.FillRectangle(new SolidBrush(Helpers.FromHex("#DBDBDB")), 4, 4, 14, 14);
		}
		bool @checked = this._checked;
		if (@checked)
		{
			graphics.FillRectangle(new SolidBrush(Helpers.FromHex("#435363")), 7, 7, 9, 9);
		}
		graphics.DrawRectangle(new Pen(Helpers.FromHex("#435363")), new Rectangle(4, 4, 14, 14));
		graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), new Rectangle(22, 0, base.Width, base.Height), new StringFormat
		{
			LineAlignment = StringAlignment.Center
		});
	}

	// Token: 0x0600001C RID: 28 RVA: 0x00002416 File Offset: 0x00000616
	protected override void OnTextChanged(EventArgs e)
	{
		base.OnTextChanged(e);
		base.Invalidate();
	}

	// Token: 0x0600001D RID: 29 RVA: 0x0000263C File Offset: 0x0000083C
	protected override void OnMouseUp(MouseEventArgs e)
	{
		base.OnMouseUp(e);
		bool @checked = this.Checked;
		if (@checked)
		{
			if (@checked)
			{
				this.Checked = false;
			}
		}
		else
		{
			this.Checked = true;
		}
		this._state = Helpers.MouseState.Hover;
		base.Invalidate();
	}

	// Token: 0x0600001E RID: 30 RVA: 0x00002686 File Offset: 0x00000886
	protected override void OnMouseEnter(EventArgs e)
	{
		base.OnMouseEnter(e);
		this._state = Helpers.MouseState.Hover;
		base.Invalidate();
	}

	// Token: 0x0600001F RID: 31 RVA: 0x0000269F File Offset: 0x0000089F
	protected override void OnMouseHover(EventArgs e)
	{
		base.OnMouseHover(e);
		this._state = Helpers.MouseState.Hover;
		base.Invalidate();
	}

	// Token: 0x06000020 RID: 32 RVA: 0x000026B8 File Offset: 0x000008B8
	protected override void OnMouseLeave(EventArgs e)
	{
		base.OnMouseLeave(e);
		this._state = Helpers.MouseState.None;
		base.Invalidate();
	}

	// Token: 0x06000021 RID: 33 RVA: 0x000026D1 File Offset: 0x000008D1
	protected override void OnMouseDown(MouseEventArgs e)
	{
		base.OnMouseDown(e);
		this._state = Helpers.MouseState.Down;
		base.Invalidate();
	}

	// Token: 0x06000022 RID: 34 RVA: 0x000026EA File Offset: 0x000008EA
	protected override void OnResize(EventArgs e)
	{
		base.OnResize(e);
		base.Invalidate();
	}

	// Token: 0x04000006 RID: 6
	private Helpers.MouseState _state = Helpers.MouseState.None;

	// Token: 0x04000008 RID: 8
	private bool _autoSize = true;

	// Token: 0x04000009 RID: 9
	private bool _checked = false;

	// Token: 0x02000017 RID: 23
	// (Invoke) Token: 0x060000EB RID: 235
	public delegate void CheckChangedEventHandler(object sender, EventArgs e);
}
