using System;                         // IntPtr
using System.Runtime.InteropServices;
using System.IO;
using System.ComponentModel;

namespace Pcie.Win
{
	//---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	///   Wraps some of the Win32 API methods provided by SetupApi.dll.
	/// </summary>
	//---------------------------------------------------------------------------------------------------------------------------
	public static class SetupApiMethods
	{
		#region Fields

		private const int INVALID_HANDLE_VALUE = -1;

		private const int MaxDevicePathSize = 256;

		#endregion Fields

		#region DLL Imports

		/// <summary>
		/// 
		/// </summary>
		/// <param name="classGuid"></param>
		/// <param name="enumerator"></param>
		/// <param name="hwndParent"></param>
		/// <param name="flags"></param>
		/// <returns>Handle to the device information set that contains all devices that matched the supplied parameters, or INVALID_HANDLE_VALUE if the function fails.</returns>
		[DllImport("setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public extern static nint SetupDiGetClassDevs([In] ref Guid classGuid, nint enumerator, nint hwndParent,
			DIGCF flags);

		[DllImport("setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public extern static nint SetupDiGetClassDevs(nint classGuid, string enumerator, nint hwndParent,
			DIGCF flags);

		[DllImport("setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public extern static bool SetupDiEnumDeviceInterfaces(nint hDevInfo, [In] ref SP_DEVINFO_DATA devInfoData,
			[In] ref Guid interfaceClassGuid, uint memberIndex,[In, Out] ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData);

		[DllImport("setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public extern static bool SetupDiEnumDeviceInterfaces(nint hDevInfo, nint devInfoData, [In] ref Guid interfaceClassGuid,
			uint memberIndex, [In, Out] ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData);

		[DllImport("setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public extern static bool SetupDiGetDeviceInterfaceDetail(nint hDevInfo,
			[In] ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData,
			[In, Out] ref SP_DEVICE_INTERFACE_DETAIL_DATA deviceInterfaceDetailData, uint deviceInterfaceDetailDataSize,
			out uint requiredSize, [In, Out] ref SP_DEVINFO_DATA deviceInfoData);

		/// <summary>
		///   Retrieves the specified device property.
		/// </summary>
		/// 
		/// <param name="hDevInfo">Handle to the device information set that contains the interface and its underlying device.</param>
		/// <param name="devInfo"><see cref="SP_DEVINFO_DATA"/> structure that defines the device instance.</param>
		/// <param name="property">Device property to be retrieved.</param>
		/// <param name="propertyRegDataType">Data type of the registry value received. This parameter can be null.</param>
		/// <param name="propertyBuffer">Buffer that receives the requested device property.</param>
		/// <param name="propertyBufferSize">Size of the buffer, in bytes.</param>
		/// <param name="requiredSize">Receives the required buffer size, in bytes. This parameter can be null.</param>
		/// <returns>True if the function succeeds, false otherwise.</returns>
		[DllImport("setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public extern static bool SetupDiGetDeviceRegistryProperty(nint hDevInfo, [In] ref SP_DEVINFO_DATA devInfo,
			SPDRP property, out uint propertyRegDataType, byte[] propertyBuffer, uint propertyBufferSize,
			out uint requiredSize);

		[DllImport("setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public extern static bool SetupDiGetDeviceRegistryProperty(nint hDevInfo, [In] ref SP_DEVINFO_DATA devInfo,
			SPDRP property, nint propertyRegDataType, byte[] propertyBuffer, uint propertyBufferSize, out uint requiredSize);

		[DllImport("setupapi.dll", ExactSpelling = true, CharSet = CharSet.Auto, SetLastError = true)]
		public extern static bool SetupDiDestroyDeviceInfoList(nint hDevInfo);

		#endregion DLL Imports

		#region Methods

		/// <summary>
		///   Pulls the first found device path from the device manager corresponding to the specified GUID.
		/// </summary>
		/// 
		/// <returns>Device path of the specified device or null if no device was found.</returns>
		public static string GetFirstFoundDevicePath(string guid)
		{
			Guid deviceGuid = new Guid(guid);
			return GetFirstFoundDevicePath(deviceGuid);
		}

		/// <summary>
		///   Pulls the first found device path from the device manager corresponding to the specified GUID.
		/// </summary>
		/// 
		/// <returns>Device path of the specified device or null if no device was found.</returns>
		public static string GetFirstFoundDevicePath(Guid deviceGuid)
		{
			// Retrieve the device information structure for all class devices.
			nint devInfo = SetupDiGetClassDevs(ref deviceGuid, nint.Zero, nint.Zero, DIGCF.DEVICEINTERFACE | DIGCF.PRESENT);

			if(devInfo.ToInt32() == INVALID_HANDLE_VALUE)
			{
				throw new IOException("Unable to pull the device information for Data Processing devices from the system",
					new Win32Exception(Marshal.GetLastWin32Error()));
			}

			try
			{
				bool success = true;
				uint count = 0;
				while(success)
				{
					// Pull the device interface information for the pulled device.
					SP_DEVICE_INTERFACE_DATA deviceInterfaceData = new SP_DEVICE_INTERFACE_DATA();
					deviceInterfaceData.cbSize = (uint)Marshal.SizeOf(typeof(SP_DEVICE_INTERFACE_DATA));
					success = SetupDiEnumDeviceInterfaces(devInfo, nint.Zero, ref deviceGuid, count, ref deviceInterfaceData);

					// Start the enumeration.
					if(success)
					{
						// Pull the device interface detail.
						SP_DEVINFO_DATA deviceInfoData = new SP_DEVINFO_DATA();
						deviceInfoData.cbSize = (uint)Marshal.SizeOf(typeof(SP_DEVINFO_DATA));
						SP_DEVICE_INTERFACE_DETAIL_DATA deviceInterfaceDetail = new SP_DEVICE_INTERFACE_DETAIL_DATA();
						deviceInterfaceDetail.cbSize = sizeof(int) + Marshal.SystemDefaultCharSize;
						uint requiredSize = 0;
						uint numBytes = MaxDevicePathSize;
						if(SetupDiGetDeviceInterfaceDetail(devInfo, ref deviceInterfaceData, ref deviceInterfaceDetail, numBytes, out requiredSize, ref deviceInfoData))
						{
							return deviceInterfaceDetail.DevicePath;
						}
					}
				}
			}
			finally
			{
				SetupDiDestroyDeviceInfoList(devInfo);
			}

			return null;
		}

		#endregion Methods
	}
}
