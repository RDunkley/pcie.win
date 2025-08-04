using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Pcie.Win
{
	[StructLayout(LayoutKind.Sequential)]
	public struct SP_DEVINFO_DATA
	{
		#region Fields

		public uint cbSize;
		public Guid ClassGuid;
		public uint DevInst;
		public nint Reserved;

		#endregion Fields

		#region Methods

		#endregion Methods
	}
}
