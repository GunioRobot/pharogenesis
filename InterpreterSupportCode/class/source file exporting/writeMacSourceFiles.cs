writeMacSourceFiles
	"Store into this image's folder the C sources files required to support the interpreter on the Macintosh. It also generates the code for the sound synthesis primitives. However, because generating code for the interpreter itself takes several minutes, that is not done automatically by this method. To generate that code, use the method 'translate:doInlining:' in Interpreter class."
	"InterpreterSupportCode writeMacSourceFiles"

	self storeString: self readmeFile			onFileNamed: 'readme'.
	self storeString: self squeakHeaderFile	onFileNamed: 'sq.h'.
	self storeString: self squeakConfigFile	onFileNamed: 'sqConfig.h'.
	self storeString: self squeakMachDepFile	onFileNamed: 'sqMachDep.h'.
	self storeString: self squeakPlatSpecFile	onFileNamed: 'sqPlatformSpecific.h'.
	self storeString: self squeakFilePrimsFile	onFileNamed: 'sqFilePrims.c'.
	self storeString: self macDirectoryFile	onFileNamed: 'sqMacDirectory.c'.
	self storeString: self macJoystickFile		onFileNamed: 'sqMacJoystick.c'.
	self storeString: self macNetworkFile		onFileNamed: 'sqMacNetwork.c'.
	self storeString: self macSoundFile		onFileNamed: 'sqMacSound.c'.
	self storeString: self macWindowFile		onFileNamed: 'sqMacWindow.c'.
	self storeString: self macTCPFile			onFileNamed: 'MacTCP.h'.
	self storeString: self macAddressXlationFile		onFileNamed: 'AddressXlation.h'.
	self storeString: self macDNRFile					onFileNamed: 'dnr.c'.
	self storeString: AbstractSound cCodeForSoundPrimitives
													onFileNamed: 'sqSoundPrims.c'.
	self storeString: self squeakOldSoundPrimsFile	onFileNamed: 'sqOldSoundPrims.c'.
	self storeProjectArchiveOnFileNamed: 'projectArchive.sit'.
