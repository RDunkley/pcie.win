using System;                         // IntPtr
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace Pcie.Win
{
	//---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	///   Wraps some of the Win32 API methods provided by Kernel32.dll.
	/// </summary>
	//---------------------------------------------------------------------------------------------------------------------------
	public static class Kernel32Methods
	{
		#region Fields

		//-----------------------------------------------------------------------------------------------------------------------
		/// <summary>
		///   Request all access when opening the file object that represents the device.
		/// </summary>
		//-----------------------------------------------------------------------------------------------------------------------
		public const int FILE_ANY_ACCESS = 0;

		public const int FILE_READ_ACCESS = 1;

		public const int FILE_WRITE_ACCESS = 2;

		//-----------------------------------------------------------------------------------------------------------------------
		/// <summary>
		///   Defines the type of device for the given I/O control code.
		/// </summary>
		//-----------------------------------------------------------------------------------------------------------------------
		public const int FILE_DEVICE_UNKNOWN = 0x00000022;

		//-----------------------------------------------------------------------------------------------------------------------
		/// <summary>
		///   Return value of <see cref="CreateFile"/> if the method fails to open a handle to the specified object.
		/// </summary>
		//-----------------------------------------------------------------------------------------------------------------------
		public const int INVALID_HANDLE_VALUE = -1;

		//-----------------------------------------------------------------------------------------------------------------------
		/// <summary>
		///   Specifies the buffered I/O method.
		/// </summary>
		//-----------------------------------------------------------------------------------------------------------------------
		public const int METHOD_BUFFERED = 0;

		//-----------------------------------------------------------------------------------------------------------------------
		/// <summary>
		///   Specifies the direct I/O method where the caller of DeviceIoControl will pass data to the driver.
		/// </summary>
		//-----------------------------------------------------------------------------------------------------------------------
		public const int METHOD_IN_DIRECT = 1;

		//-----------------------------------------------------------------------------------------------------------------------
		/// <summary>
		///   Specifies the direct I/O method where the caller of DeviceIoControl will receive data from the driver.
		/// </summary>
		//-----------------------------------------------------------------------------------------------------------------------
		public const int METHOD_OUT_DIRECT = 2;

		#endregion Fields

		#region DLL Imports

		//-----------------------------------------------------------------------------------------------------------------------
		/// <summary>
		///   Win32 API method to close an open object handle.
		/// </summary>
		/// 
		/// <param name="hObject">Handle to an open object.</param>
		/// 
		/// <returns>Nonzero if successful, zero otherwise.</returns>
		//-----------------------------------------------------------------------------------------------------------------------
		[DllImport("Kernel32.dll", ExactSpelling = true, CharSet = CharSet.Auto, SetLastError = true)]
		public extern static bool CloseHandle(nint hObject);

		//-----------------------------------------------------------------------------------------------------------------------
		/// <summary>
		///   Win32 API method to create or open a file, pipe, mailslot, communications resource, console, or
		///   directory (open only).
		/// </summary>
		/// 
		/// <param name="fileName">
		///   Specifies the name of the object to create or open.
		/// </param>
		/// <param name="desiredAccess">
		///   Specifies the type of access to the object.
		/// </param>
		/// <param name="shareMode">
		///   Specifies how the object can be shared.
		/// </param>
		/// <param name="securityAttributes">
		///   Pointer to security attributes structure that determines whether the returned handle can be inherited by
		///   child processes.
		/// </param>
		/// <param name="creationDisposition">
		///   Specifies which action to take on objects that exist, and which action to take when objects do not exist.
		/// </param>
		/// <param name="flagsAndAttributes">
		///   Specifies the object attributes and flags for the object.
		/// </param>
		/// <param name="templateFile">
		///   Handle to object with attributes to copy.
		/// </param>
		/// 
		/// <returns>A handle that can be used to access the object.</returns>
		//-----------------------------------------------------------------------------------------------------------------------
		[DllImport("Kernel32.dll", SetLastError = true)]
		public extern static nint CreateFile(string fileName, GenericAccessRights desiredAccess, FileShareMode shareMode,
			nint securityAttributes, CreationDisposition creationDisposition, uint flagsAndAttributes, nint templateFile);

		//-----------------------------------------------------------------------------------------------------------------------
		/// <summary>
		///   Win32 API method used to send a vendor request control code directly to a specified device driver,
		///   causing the corresponding device to perform the requested operation.
		/// </summary>
		/// 
		/// <param name="hDevice">
		///   Handle to the device.
		/// </param>
		/// <param name="IoControlCode">
		///   Control code of the operation to perform.
		/// </param>
		/// <param name="lpInBuffer">
		///   Buffer that contains the data required to perform the operation.
		/// </param>
		/// <param name="InBufferSize">
		///   Size, in bytes, of <i>lpInBuffer</i>.
		/// </param>
		/// <param name="lpOutBuffer">
		///   Pointer to the buffer that receives the operation's output data.
		/// </param>
		/// <param name="nOutBufferSize">
		///   Size, in bytes, of <i>lpOutBuffer</i>.
		/// </param>
		/// <param name="lpBytesReturned">
		///   Size, in bytes, of the data stored in <i>lpOutBuffer</i>.
		/// </param>
		/// <param name="lpOverlapped">
		///   Pointer to an overlapped structure.
		/// </param>
		/// 
		/// <returns>Nonzero if successful, zero otherwise.</returns>
		//-----------------------------------------------------------------------------------------------------------------------
//		[DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
//		public extern static bool DeviceIoControl(IntPtr hDevice, uint IoControlCode, [In, Out] ref VendorRequestIn lpInBuffer,
//			uint InBufferSize, IntPtr lpOutBuffer, uint nOutBufferSize, ref uint lpBytesReturned, IntPtr lpOverlapped);

		//-----------------------------------------------------------------------------------------------------------------------
		/// <summary>
		///   Win32 API method used to send a vendor or class request control code directly to a specified device driver,
		///   causing the corresponding device to perform the requested operation.
		/// </summary>
		/// 
		/// <param name="hDevice">
		///   Handle to the device.
		/// </param>
		/// <param name="IoControlCode">
		///   Control code of the operation to perform.
		/// </param>
		/// <param name="lpInBuffer">
		///   Buffer that contains the data required to perform the operation.
		/// </param>
		/// <param name="InBufferSize">
		///   Size, in bytes, of <i>lpInBuffer</i>.
		/// </param>
		/// <param name="outBuffer">
		///   Buffer that receives the operation's output data.
		/// </param>
		/// <param name="nOutBufferSize">
		///   Size, in bytes, of <i>lpOutBuffer</i>.
		/// </param>
		/// <param name="lpBytesReturned">
		///   Size, in bytes, of the data stored in <i>lpOutBuffer</i>.
		/// </param>
		/// <param name="lpOverlapped">
		///   Pointer to an overlapped structure.
		/// </param>
		/// 
		/// <returns>Nonzero if successful, zero otherwise.</returns>
		//-----------------------------------------------------------------------------------------------------------------------
//		[DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
//		public extern static bool DeviceIoControl(IntPtr hDevice, uint IoControlCode,
//			[In, Out] ref VendorOrClassRequestControl lpInBuffer, uint InBufferSize, [In, Out] byte[] outBuffer,
//			uint nOutBufferSize, ref uint lpBytesReturned, IntPtr lpOverlapped);

		//-----------------------------------------------------------------------------------------------------------------------
		/// <summary>
		///   Win32 API method used to send a GetStringDescriptor control code directly to a specified device driver,
		///   causing the corresponding device to perform the requested operation.
		/// </summary>
		/// 
		/// <param name="hDevice">
		///   Handle to the device.
		/// </param>
		/// <param name="IoControlCode">
		///   Control code of the operation to perform.
		/// </param>
		/// <param name="lpInBuffer">
		///   Buffer that contains the data required to perform the operation.
		/// </param>
		/// <param name="InBufferSize">
		///   Size, in bytes, of <i>lpInBuffer</i>.
		/// </param>
		/// <param name="outBuffer">
		///   Buffer that receives the operation's output data.
		/// </param>
		/// <param name="nOutBufferSize">
		///   Size, in bytes, of <i>lpOutBuffer</i>.
		/// </param>
		/// <param name="lpBytesReturned">
		///   Size, in bytes, of the data stored in <i>lpOutBuffer</i>.
		/// </param>
		/// <param name="lpOverlapped">
		///   Pointer to an overlapped structure.
		/// </param>
		/// 
		/// <returns>Nonzero if successful, zero otherwise.</returns>
		//-----------------------------------------------------------------------------------------------------------------------
//		[DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
//		public extern static bool DeviceIoControl(IntPtr hDevice, uint IoControlCode,
//			[In, Out] ref GetStringDescriptorIn lpInBuffer, uint InBufferSize, [In, Out] byte[] outBuffer, uint nOutBufferSize,
//			ref uint lpBytesReturned, IntPtr lpOverlapped);

		//-----------------------------------------------------------------------------------------------------------------------
		/// <summary>
		///   Win32 API method used to send a control code directly to a specified device driver, causing the corresponding
		///   device to perform the requested operation.
		/// </summary>
		/// 
		/// <param name="hDevice">
		///   Handle to the device.
		/// </param>
		/// <param name="IoControlCode">
		///   Control code of the operation to perform.
		/// </param>
		/// <param name="pipeNumber">
		///   Pipe to perform the operation on.
		/// </param>
		/// <param name="InBufferSize">
		///   Size, in bytes, of <i>lpInBuffer</i>.
		/// </param>
		/// <param name="outBuffer">
		///   Buffer that receives the operation's output data.
		/// </param>
		/// <param name="nOutBufferSize">
		///   Size, in bytes, of <i>lpOutBuffer</i>.
		/// </param>
		/// <param name="lpBytesReturned">
		///   Size, in bytes, of the data stored in <i>lpOutBuffer</i>.
		/// </param>
		/// <param name="lpOverlapped">
		///   Pointer to an overlapped structure.
		/// </param>
		/// 
		/// <returns>Nonzero if successful, zero otherwise.</returns>
		//-----------------------------------------------------------------------------------------------------------------------
		[DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public extern static bool DeviceIoControl(nint hDevice, uint IoControlCode, [In, Out] ref uint pipeNumber,
			uint InBufferSize, [In, Out] byte[] outBuffer, uint nOutBufferSize, ref uint lpBytesReturned, nint lpOverlapped);

		//-----------------------------------------------------------------------------------------------------------------------
		/// <summary>
		///   Win32 API method used to send a control code directly to a specified device driver, causing the corresponding
		///   device to perform the requested operation.
		/// </summary>
		/// 
		/// <param name="hDevice">
		///   Handle to the device.
		/// </param>
		/// <param name="IoControlCode">
		///   Control code of the operation to perform.
		/// </param>
		/// <param name="InBuffer">
		///   Buffer that contains the data required to perform the operation.
		/// </param>
		/// <param name="nInBufferSize">
		///   Size, in bytes, of <i>InBuffer</i>.
		/// </param>
		/// <param name="outBuffer">
		///   Buffer that receives the operation's output data. Can be null if <i>IoControlCode</i> specifies
		///   an operation that does not produce output data.
		/// </param>
		/// <param name="nOutBufferSize">
		///   Size, in bytes, of <i>outBuffer</i>.
		/// </param>
		/// <param name="pBytesReturned">
		///   Size, in bytes, of the data stored in <i>outBuffer</i>.
		/// </param>
		/// <param name="pOverlapped">
		///   Pointer to an overlapped structure.
		/// </param>
		/// 
		/// <returns>Nonzero if successful, zero otherwise.</returns>
		//-----------------------------------------------------------------------------------------------------------------------
		[DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool DeviceIoControl(nint hDevice, uint IoControlCode, byte[] InBuffer, uint nInBufferSize,
			[Out] byte[] outBuffer, uint nOutBufferSize, ref uint pBytesReturned, nint pOverlapped);

		#endregion DLL Imports

		#region Methods

		/// <summary>
		/// 
		/// </summary>
		/// <param name="devicePath"></param>
		/// <returns></returns>
		/// <exception cref="Win32Exception"></exception>
		public static nint OpenDeviceHandle(string devicePath)
		{
			nint deviceHandle = CreateFile(devicePath, GenericAccessRights.Read | GenericAccessRights.Write,
				FileShareMode.Read | FileShareMode.Write, nint.Zero, CreationDisposition.OpenExisting, 0, nint.Zero);

			if(deviceHandle.ToInt32() == INVALID_HANDLE_VALUE)
				throw new Win32Exception(Marshal.GetLastWin32Error());
			return deviceHandle;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="deviceHandle"></param>
		/// <exception cref="Win32Exception"></exception>
		public static void CloseDeviceHandle(nint deviceHandle)
		{
			if(!CloseHandle(deviceHandle))
				throw new Win32Exception(Marshal.GetLastWin32Error());
		}

		//-----------------------------------------------------------------------------------------------------------------------
		/// <summary>
		///   Macro used to create a unique system I/O control code. This value identifies the specific operation to be performed
		///   and the type of device on which the operation is to be performed.
		/// </summary>
		/// 
		/// <param name="DeviceType">
		///   Identifies the device type.
		/// </param>
		/// <param name="Function">
		///   Identifies the function to be performed by the driver.
		/// </param>
		/// <param name="Method">
		///   Indicates how the system will pass data between the caller of DeviceIoControl and the driver.
		/// </param>
		/// <param name="Access">
		///   Indicates the type of access that a caller must request when opening the file object that represents the device.
		/// </param>
		/// 
		/// <returns>A 32-bit unsigned integer representing the I/O control code of the operation to perform.</returns>
		/// 
		/// <remarks>
		///   The macro combines the individual bit flag parameters in this method into a single I/O control code bit flag. The
		///   following illustration shows the format of this control code.
		/// <code>
		///        ______________________________
		///       |              | |           | |
		/// bits: 31            16 14          2 0
		///        \____________/\_/\_________/\_/
		///              |        |       |     |
		///         Device Type   |   Function  |
		///                    Access        Method
		/// </code></remarks>
		//-----------------------------------------------------------------------------------------------------------------------
		public static uint CTL_CODE(uint DeviceType, uint Function, uint Method, uint Access)
		{
			return DeviceType << 16 | Access << 14 | Function << 2 | Method;
		}

		#endregion Methods
	}
}
