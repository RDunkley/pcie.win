using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Pcie.Win
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct SP_DEVICE_INTERFACE_DETAIL_DATA
	{
		public int cbSize;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string DevicePath;
	}
}
