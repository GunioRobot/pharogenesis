writePluginSupportFiles
	"InterpreterSupportCode writePluginSupportFiles"

	self	storeString: self squeakConfigFile onFileNamed: 'sqConfig.h'.
	self	storeString: self squeakPlatSpecFile onFileNamed: 'sqPlatformSpecific.h'.
	self	storeString: self squeakVirtualMachineHeaderFile onFileNamed: 'sqVirtualMachine.h'.
