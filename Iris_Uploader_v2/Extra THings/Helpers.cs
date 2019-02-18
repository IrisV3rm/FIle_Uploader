using System;
using System.Drawing;
using System.IO;

// Token: 0x02000002 RID: 2
public static class Helpers
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	public static Image b64Image(string b64)
	{
		return Image.FromStream(new MemoryStream(Convert.FromBase64String(b64)));
	}

	// Token: 0x06000002 RID: 2 RVA: 0x00002074 File Offset: 0x00000274
	public static Color FromHex(string hex)
	{
		return ColorTranslator.FromHtml(hex);
	}

	// Token: 0x02000015 RID: 21
	public enum MouseState
	{
		// Token: 0x0400008B RID: 139
		Hover = 1,
		// Token: 0x0400008C RID: 140
		Down,
		// Token: 0x0400008D RID: 141
		None
	}

	// Token: 0x02000016 RID: 22
	public enum TxtAlign
	{
		// Token: 0x0400008F RID: 143
		Left = 1,
		// Token: 0x04000090 RID: 144
		Center,
		// Token: 0x04000091 RID: 145
		Right
	}
}
