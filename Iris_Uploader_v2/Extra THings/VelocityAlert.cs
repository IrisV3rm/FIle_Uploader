using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

// Token: 0x02000008 RID: 8
[DefaultEvent("XClicked")]
public class VelocityAlert : Control
{
	// Token: 0x14000003 RID: 3
	// (add) Token: 0x0600003C RID: 60 RVA: 0x00002DA4 File Offset: 0x00000FA4
	// (remove) Token: 0x0600003D RID: 61 RVA: 0x00002DDC File Offset: 0x00000FDC
	public event VelocityAlert.XClickedEventHandler XClicked;

	// Token: 0x1700000B RID: 11
	// (get) Token: 0x0600003E RID: 62 RVA: 0x00002E14 File Offset: 0x00001014
	// (set) Token: 0x0600003F RID: 63 RVA: 0x00002E2C File Offset: 0x0000102C
	public bool XChangeCursor
	{
		get
		{
			return this._xChangeCursor;
		}
		set
		{
			this._xChangeCursor = value;
			base.Invalidate();
		}
	}

	// Token: 0x1700000C RID: 12
	// (get) Token: 0x06000040 RID: 64 RVA: 0x00002E40 File Offset: 0x00001040
	// (set) Token: 0x06000041 RID: 65 RVA: 0x00002E58 File Offset: 0x00001058
	public string Title
	{
		get
		{
			return this._title;
		}
		set
		{
			this._title = value;
			base.Invalidate();
		}
	}

	// Token: 0x1700000D RID: 13
	// (get) Token: 0x06000042 RID: 66 RVA: 0x00002E6C File Offset: 0x0000106C
	// (set) Token: 0x06000043 RID: 67 RVA: 0x00002E84 File Offset: 0x00001084
	public bool ShowExit
	{
		get
		{
			return this._exitButton;
		}
		set
		{
			this._exitButton = value;
			base.Invalidate();
		}
	}

	// Token: 0x1700000E RID: 14
	// (get) Token: 0x06000044 RID: 68 RVA: 0x00002E98 File Offset: 0x00001098
	// (set) Token: 0x06000045 RID: 69 RVA: 0x00002EB0 File Offset: 0x000010B0
	public bool ShowImage
	{
		get
		{
			return this._showImage;
		}
		set
		{
			this._showImage = value;
			base.Invalidate();
		}
	}

	// Token: 0x1700000F RID: 15
	// (get) Token: 0x06000046 RID: 70 RVA: 0x00002EC4 File Offset: 0x000010C4
	// (set) Token: 0x06000047 RID: 71 RVA: 0x00002EDC File Offset: 0x000010DC
	public Image Image
	{
		get
		{
			return this._image;
		}
		set
		{
			this._image = value;
			base.Invalidate();
		}
	}

	// Token: 0x17000010 RID: 16
	// (get) Token: 0x06000048 RID: 72 RVA: 0x00002EF0 File Offset: 0x000010F0
	// (set) Token: 0x06000049 RID: 73 RVA: 0x00002F08 File Offset: 0x00001108
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

	// Token: 0x0600004A RID: 74 RVA: 0x00002F1C File Offset: 0x0000111C
	public VelocityAlert()
	{
		base.Size = new Size(370, 80);
		this.DoubleBuffered = true;
	}

	// Token: 0x0600004B RID: 75 RVA: 0x00002F90 File Offset: 0x00001190
	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		Graphics graphics = e.Graphics;
		graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
		bool showImage = this.ShowImage;
		if (showImage)
		{
			if (showImage)
			{
				bool flag = this._image == null;
				if (flag)
				{
					graphics.DrawImage(Helpers.b64Image(this.FillerImage), 13, 8);
				}
				else
				{
					graphics.DrawImage(this._image, 12, 8, 64, 64);
				}
				graphics.DrawString(this._title, new Font("Segoe UI Semilight", 14f), new SolidBrush(this.ForeColor), 84f, 6f);
				graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), new Rectangle(86, 33, base.Width - 88, base.Height - 10));
			}
		}
		else
		{
			graphics.DrawString(this._title, new Font("Segoe UI Semilight", 14f), new SolidBrush(this.ForeColor), 18f, 6f);
			graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), new Rectangle(20, 33, base.Width - 28, base.Height - 10));
		}
		bool showExit = this.ShowExit;
		if (showExit)
		{
			bool xHover = this._xHover;
			if (xHover)
			{
				graphics.DrawString("r", new Font("Marlett", 9f), new SolidBrush(Helpers.FromHex("#596372")), (float)(base.Width - 18), 4f);
			}
			else
			{
				graphics.DrawString("r", new Font("Marlett", 9f), new SolidBrush(Helpers.FromHex("#435363")), (float)(base.Width - 18), 4f);
			}
		}
		graphics.DrawRectangle(new Pen(this._border), 0, 0, base.Width - 1, base.Height - 1);
		graphics.FillRectangle(new SolidBrush(this._border), 0, 0, 6, base.Height);
	}

	// Token: 0x0600004C RID: 76 RVA: 0x000031C0 File Offset: 0x000013C0
	protected override void OnMouseMove(MouseEventArgs e)
	{
		base.OnMouseMove(e);
		bool exitButton = this._exitButton;
		if (exitButton)
		{
			bool flag = new Rectangle(base.Width - 16, 4, 12, 13).Contains(e.X, e.Y);
			if (flag)
			{
				this._xHover = true;
				bool xChangeCursor = this._xChangeCursor;
				if (xChangeCursor)
				{
					this.Cursor = Cursors.Hand;
				}
			}
			else
			{
				this._xHover = false;
				this.Cursor = Cursors.Default;
			}
		}
		base.Invalidate();
	}

	// Token: 0x0600004D RID: 77 RVA: 0x0000324C File Offset: 0x0000144C
	protected override void OnMouseUp(MouseEventArgs e)
	{
		base.OnMouseUp(e);
		bool exitButton = this._exitButton;
		if (exitButton)
		{
			bool xHover = this._xHover;
			if (xHover)
			{
				bool flag = this.XClicked != null;
				if (flag)
				{
					this.XClicked(this, EventArgs.Empty);
				}
			}
		}
	}

	// Token: 0x0600004E RID: 78 RVA: 0x00002416 File Offset: 0x00000616
	protected override void OnTextChanged(EventArgs e)
	{
		base.OnTextChanged(e);
		base.Invalidate();
	}

	// Token: 0x04000011 RID: 17
	private bool _xHover = false;

	// Token: 0x04000012 RID: 18
	private string FillerImage = "iVBORw0KGgoAAAANSUhEUgAAAEAAAABACAIAAAAlC+aJAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAAZdEVYdFNvZnR3YXJlAHBhaW50Lm5ldCA0LjAuMTM0A1t6AAADZUlEQVRoQ+2W2ytsYRjG9x85Cikpp1KORSkihITkyinkdCERm0wi3IiS5ELKIQkXkiQkh9m/tZ7PNHuwWi707dl9v4vpfd/1zut51ncYvyIpzv9iIJaCSLkzYA8pdwbsIeXOgD2k3Bmwh5Q7A/aQcmfAHlLuDNhDyp0Be0i5M2APKXcG7CHlzoA9pPx7Bh4fH4+Pj/f29m5vb03pHSpnZ2cmCeTt7Y1OhlxdXZnSO8/PzyGHgJR/w8Dc3Fx6err6s7OzTdXn9fW1sLCQ+urqqil9AQ15eXkaAkdHR+aBT21tLcWJiQmTB6IJYQ1sbW3RtrKyovTy8lKBGBsb05zl5WVT+ozT01N6pqenlSatwNLSkoaMjIyYUiBqDmugoaGhr6/PJH/DojNhf3+fz2g0SoXPqampu7s7Nfz2Iejt7W1sbFQxiaenJ1YG/wwZHBw01UA83eENsHnW1tZ4Z4eHh/f396bq09bW1tLSQpE5MgBFRUWdnZ0EJycn1Dc2NojLysrYHhhjSNIpGh4ezs/PJ6C5v79fxWA83SENXF9f01NVVaVmGBgY0KPNzU1SgiQDKCZlx1dUVHR0dKiYlZVVWlrqfd+nvb1ddS4G0ouLC2ICFkr1YPwZ4Qycn5/TMzQ0pHRmZoYU6cTl5eXaHkkGoLm52Rsdidzc3JBy+RC3trZqASV6dnaWmAXs6enxvvNDBlh0era3t00eixUUFKCb45iZmcnqj4+P6xwjJf5eFxYWqLACSiEnJ4erzCSxWF1dHedKa8W+ZwIbjJillrFg6ISwZyA3N3d+fl4xvwZpaWmsAAa6u7u7uro4Bk1NTcwpLi4uKSmhhy3OsRkdHaUY/2JNTU187wHNTMAAQwDnGsJhYKZp+hpPd3gD/IHq6moOw8vLC++JG4O73zzzeXh4YA4HXSn99fX1BLzajIwM7aLJyUl+Lg4ODogXFxfpZ3N63QmwpD9yjfJGWXE18+Z2d3fNg3cSDezs7BDHf1MrKytJFbNW3ohIhO20vr6uYiIsNXvJJIFoTlgDgs3DhW2SD3z8/+JTmJB0EScScghI+fcM/FNIuTNgDyl3Buwh5c6APaTcGbCHlDsD9pByZ8AeUu4M2EPKnQF7SLkzYA8pdwbsIeXOgD2k3Bmwh5QbA6lLihuIRP4AXubLj7lh8ksAAAAASUVORK5CYII=";

	// Token: 0x04000013 RID: 19
	private bool _xChangeCursor = true;

	// Token: 0x04000014 RID: 20
	private string _title = "";

	// Token: 0x04000015 RID: 21
	private bool _exitButton = false;

	// Token: 0x04000016 RID: 22
	private bool _showImage = true;

	// Token: 0x04000017 RID: 23
	private Image _image;

	// Token: 0x04000018 RID: 24
	private Color _border = Helpers.FromHex("#435363");

	// Token: 0x02000019 RID: 25
	// (Invoke) Token: 0x060000F3 RID: 243
	public delegate void XClickedEventHandler(object sender, EventArgs e);
}
