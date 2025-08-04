using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Pcie.Win
{
	[StructLayout(LayoutKind.Sequential)]
	public struct SP_DEVICE_INTERFACE_DATA
	{
		#region Fields

		/// <summary>
		///   Size of the structure in bytes.
		/// </summary>
		public uint cbSize;

		/// <summary>
		///   GUID of the device interface class.
		/// </summary>
		public Guid interfaceClassGuid;

		/// <summary>
		///   One of the SPINT_ values.
		/// </summary>
		public uint flags;

		/// <summary>
		///   Reserved, do not use.
		/// </summary>
		public nuint reserved;

		#endregion Fields

	}
}
