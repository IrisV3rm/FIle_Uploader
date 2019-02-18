using System;
using System.Drawing;
using System.Windows.Forms;

// Token: 0x02000009 RID: 9
public class VelocityTabControl : TabControl
{
	// Token: 0x17000011 RID: 17
	// (get) Token: 0x0600004F RID: 79 RVA: 0x0000329C File Offset: 0x0000149C
	// (set) Token: 0x06000050 RID: 80 RVA: 0x000032B4 File Offset: 0x000014B4
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

	// Token: 0x06000051 RID: 81 RVA: 0x000032C8 File Offset: 0x000014C8
	public VelocityTabControl()
	{
		base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		this.DoubleBuffered = true;
		base.SizeMode = TabSizeMode.Fixed;
		base.ItemSize = new Size(40, 130);
		base.Alignment = TabAlignment.Left;
		this.Font = new Font("Segoe UI Semilight", 9f);
	}

	// Token: 0x06000052 RID: 82 RVA: 0x0000333C File Offset: 0x0000153C
	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		Bitmap bitmap = new Bitmap(base.Width, base.Height);
		Graphics graphics = Graphics.FromImage(bitmap);
		graphics.Clear(Color.FromArgb(37, 37, 37));
		int num = 13;
		for (int i = 0; i <= base.TabCount - 1; i++)
		{
			Rectangle tabRect = base.GetTabRect(i);
			bool flag = i == base.SelectedIndex;
			if (flag)
			{
				graphics.FillRectangle(new SolidBrush(Color.FromArgb(50, 50, 50)), tabRect);
			}
			else
			{
				bool flag2 = i == this._overtab;
				if (flag2)
				{
					graphics.FillRectangle(new SolidBrush(Color.FromArgb(40, 40, 40)), tabRect);
				}
				else
				{
					graphics.FillRectangle(new SolidBrush(Color.FromArgb(37, 37, 37)), tabRect);
				}
			}
			switch (this._txtAlign)
			{
			case Helpers.TxtAlign.Left:
				graphics.DrawString(base.TabPages[i].Text, this.Font, Brushes.White, new Rectangle(tabRect.X + 8, tabRect.Y, tabRect.Width, tabRect.Height), new StringFormat
				{
					Alignment = StringAlignment.Near,
					LineAlignment = StringAlignment.Center
				});
				break;
			case Helpers.TxtAlign.Center:
				graphics.DrawString(base.TabPages[i].Text, this.Font, Brushes.White, tabRect, new StringFormat
				{
					Alignment = StringAlignment.Center,
					LineAlignment = StringAlignment.Center
				});
				break;
			case Helpers.TxtAlign.Right:
				graphics.DrawString(base.TabPages[i].Text, this.Font, Brushes.White, new Rectangle(tabRect.X - 8, tabRect.Y, tabRect.Width, tabRect.Height), new StringFormat
				{
					Alignment = StringAlignment.Far,
					LineAlignment = StringAlignment.Center
				});
				break;
			}
			bool flag3 = base.TabPages[i].Tag != null;
			if (flag3)
			{
				graphics.DrawImage(Helpers.b64Image((string)base.TabPages[i].Tag), 15, tabRect.Y + 8, 25, 25);
			}
			num += 40 - i;
		}
		e.Graphics.DrawImage(bitmap, 0, 0);
		graphics.Dispose();
		bitmap.Dispose();
	}

	// Token: 0x06000053 RID: 83 RVA: 0x000035BC File Offset: 0x000017BC
	protected override void OnMouseMove(MouseEventArgs e)
	{
		base.OnMouseMove(e);
		for (int i = 0; i <= base.TabPages.Count - 1; i++)
		{
			bool flag = base.GetTabRect(i).Contains(e.Location);
			if (flag)
			{
				this._overtab = i;
			}
			base.Invalidate();
		}
	}

	// Token: 0x04000019 RID: 25
	private int _overtab = 0;

	// Token: 0x0400001A RID: 26
	private Helpers.TxtAlign _txtAlign = Helpers.TxtAlign.Center;
}
