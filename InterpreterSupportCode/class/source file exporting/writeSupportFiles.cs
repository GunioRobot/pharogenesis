writeSupportFiles
	"Store into this image's folder the C sources files required to support the interpreter on all platforms. This method also generates the code for the sound synthesis and other primitives translated from Smalltalk to C. However, because generating code for the interpreter itself takes several minutes, that is not done automatically by this method. To generate that code, use the method 'translate:doInlining:' in Interpreter class."
	"InterpreterSupportCode writeSupportFiles"

	self storeString: self readmeFile			onFileNamed: 'readme'.
	self storeString: self squeakHeaderFile	onFileNamed: 'sq.h'.
	self storeString: self squeakConfigFile	onFileNamed: 'sqConfig.h'.
	self storeString: self squeakPlatformExportsFile	onFileNamed: 'platform.exports'.
	self storeString: self squeakPlatSpecFile	onFileNamed: 'sqPlatformSpecific.h'.
	self storeString: self squeakVirtualMachineHeaderFile	onFileNamed: 'sqVirtualMachine.h'.
	self storeString: self squeakVirtualMachineFile	onFileNamed: 'sqVirtualMachine.c'.
	self storeString: self squeakNamedPrimsFile onFileNamed:'sqNamedPrims.c'.

	self storeString: self squeakFilePrimsFile	onFileNamed:  'sqFilePrims.c'.