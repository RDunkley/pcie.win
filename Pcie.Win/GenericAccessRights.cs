using System;
using System.Collections.Generic;
using System.Text;

namespace Pcie.Win
{
	[Flags]
	public enum GenericAccessRights: uint
	{
		None = 0x00000000,
		All = 0x10000000,
		Execute = 0x20000000,
		Write = 0x40000000,
		Read = 0x80000000,
	}
}
