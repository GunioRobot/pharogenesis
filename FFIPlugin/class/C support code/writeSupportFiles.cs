writeSupportFiles
	"FFIPlugin writeSupportFiles"
	InterpreterSupportCode
		storeString: self sqFFIHeaderFile onFileNamed:'sqFFI.h';
		storeString: self sqMacFFIPPCFile onFileNamed:'sqMacFFIPPC.c';
		storeString: self sqUnixFFIFile onFileNamed:'sqUnixFFI.c';
		storeString: self sqWin32FFIFile onFileNamed:'sqWin32FFI.c'.