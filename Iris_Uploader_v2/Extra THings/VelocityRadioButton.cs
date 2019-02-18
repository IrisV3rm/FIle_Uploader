using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

// Token: 0x02000005 RID: 5
[DefaultEvent("CheckChanged")]
public class VelocityRadioButton : Control
{
	// Token: 0x14000002 RID: 2
	// (add) Token: 0x06000023 RID: 35 RVA: 0x000026FC File Offset: 0x000008FC
	// (remove) Token: 0x06000024 RID: 36 RVA: 0x00002734 File Offset: 0x00000934
	public event VelocityRadioButton.CheckChangedEventHandler CheckChanged;

	// Token: 0x17000007 RID: 7
	// (get) Token: 0x06000025 RID: 37 RVA: 0x0000276C File Offset: 0x0000096C
	// (set) Token: 0x06000026 RID: 38 RVA: 0x00002784 File Offset: 0x00000984
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

	// Token: 0x17000008 RID: 8
	// (get) Token: 0x06000027 RID: 39 RVA: 0x00002798 File Offset: 0x00000998
	// (set) Token: 0x06000028 RID: 40 RVA: 0x000027B0 File Offset: 0x000009B0
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

	// Token: 0x06000029 RID: 41 RVA: 0x000027C1 File Offset: 0x000009C1
	public VelocityRadioButton()
	{
		this.DoubleBuffered = true;
		this.InvalidateControls();
	}

	// Token: 0x0600002A RID: 42 RVA: 0x000027E8 File Offset: 0x000009E8
	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		bool autoSize = this.AutoSize;
		if (autoSize)
		{
			base.Size = new Size(TextRenderer.MeasureText(this.Text, this.Font).Width + 24, base.Height);
		}
		Graphics graphics = e.Graphics;
		graphics.SmoothingMode = SmoothingMode.HighQuality;
		Helpers.MouseState state = this._state;
		if (state != Helpers.MouseState.Hover)
		{
			graphics.FillEllipse(Brushes.White, 4, 4, 14, 14);
		}
		else
		{
			graphics.FillEllipse(new SolidBrush(Helpers.FromHex("#DBDBDB")), 4, 4, 14, 14);
		}
		graphics.DrawEllipse(new Pen(Helpers.FromHex("#435363")), new Rectangle(4, 4, 14, 14));
		graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), new Rectangle(22, 0, base.Width, base.Height), new StringFormat
		{
			LineAlignment = StringAlignment.Center
		});
		bool @checked = this._checked;
		if (@checked)
		{
			graphics.FillEllipse(new SolidBrush(Helpers.FromHex("#435363")), 7, 7, 8, 8);
		}
	}

	// Token: 0x0600002B RID: 43 RVA: 0x00002918 File Offset: 0x00000B18
	private void InvalidateControls()
	{
		bool flag = !base.IsHandleCreated || !this._checked;
		if (!flag)
		{
			foreach (object obj in base.Parent.Controls)
			{
				Control control = (Control)obj;
				bool flag2 = control != this && control is VelocityRadioButton;
				if (flag2)
				{
					((VelocityRadioButton)control).Checked = false;
					base.Invalidate();
				}
			}
		}
	}

	// Token: 0x0600002C RID: 44 RVA: 0x00002416 File Offset: 0x00000616
	protected override void OnTextChanged(EventArgs e)
	{
		base.OnTextChanged(e);
		base.Invalidate();
	}

	// Token: 0x0600002D RID: 45 RVA: 0x000029BC File Offset: 0x00000BBC
	protected override void OnMouseUp(MouseEventArgs e)
	{
		base.OnMouseUp(e);
		this._state = Helpers.MouseState.Hover;
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
		this.InvalidateControls();
	}

	// Token: 0x0600002E RID: 46 RVA: 0x00002A0D File Offset: 0x00000C0D
	protected override void OnMouseHover(EventArgs e)
	{
		base.OnMouseHover(e);
		this._state = Helpers.MouseState.Hover;
		base.Invalidate();
	}

	// Token: 0x0600002F RID: 47 RVA: 0x00002A26 File Offset: 0x00000C26
	protected override void OnMouseLeave(EventArgs e)
	{
		base.OnMouseLeave(e);
		this._state = Helpers.MouseState.None;
		base.Invalidate();
	}

	// Token: 0x06000030 RID: 48 RVA: 0x00002A3F File Offset: 0x00000C3F
	protected override void OnMouseDown(MouseEventArgs e)
	{
		base.OnMouseDown(e);
		this._state = Helpers.MouseState.None;
		base.Invalidate();
	}

	// Token: 0x06000031 RID: 49 RVA: 0x000026EA File Offset: 0x000008EA
	protected override void OnResize(EventArgs e)
	{
		base.OnResize(e);
		base.Invalidate();
	}

	// Token: 0x0400000A RID: 10
	private Helpers.MouseState _state;

	// Token: 0x0400000C RID: 12
	private bool _autoSize = true;

	// Token: 0x0400000D RID: 13
	private bool _checked = false;

	// Token: 0x02000018 RID: 24
	// (Invoke) Token: 0x060000EF RID: 239
	public delegate void CheckChangedEventHandler(object sender, EventArgs e);
}
