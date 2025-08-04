using System;
using System.Collections.Generic;
using System.Text;

namespace Pcie.Win
{
	/// <summary>
	///   Specifies control options that filter the device information elements that are added to the device information set when
	///   <see cref="SetupApiMethods.SetupDiGetClassDevs"/> is called.
	/// </summary>
	public enum DIGCF : uint
	{
		/// <summary>
		///   Return only the device that is associated with the system default device interface, if one is set, for the specified
		///   device interface classes.
		/// </summary>
		DEFAULT = 0x01,

		/// <summary>
		///   Return only devices that are currently present in a system.
		/// </summary>
		PRESENT = 0x02,

		/// <summary>
		///   Return a list of installed devices for all device setup classes or all device interface classes.
		/// </summary>
		ALLCLASSES = 0x04,

		/// <summary>
		///   Return only device that are a part of the current hardware profile.
		/// </summary>
		PROFILE = 0x08,

		/// <summary>
		///   Return devices that support device interfaces for the specified device interface classes. This flag must be set in
		///   the Flags parameter if the Enumerator parameter specifies a device instance ID.
		/// </summary>
		DEVICEINTERFACE = 0x10,
	}
}
