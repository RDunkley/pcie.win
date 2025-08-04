using System;
using System.Collections.Generic;
using System.Text;

namespace Pcie.Win
{
	/// <summary>
	///   Specifies the action to take on a file or device that exists or does not exist when opening.
	/// </summary>
	/// 
	/// <remarks><see cref="OpenExisting"/> is usually used when opening devices other than files.</remarks>
	public enum CreationDisposition : uint
	{
		CreateAlways = 2,
		CreateNew = 1,
		OpenAlways = 4,
		OpenExisting = 3,
		TruncateExisting = 5,
	}
}
