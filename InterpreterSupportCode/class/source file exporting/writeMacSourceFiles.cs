writeMacSourceFiles
	"Store into this image's folder the C sources files required to support the interpreter on the Macintosh. It also generates the code for the sound synthesis primitives. However, because generating code for the interpreter itself takes several minutes, that is not done automatically by this method. To generate the interpreter code, use the method 'translate:doInlining:' in Interpreter class."
	"InterpreterSupportCode writeMacSourceFiles"

	self writeSupportFiles.
	FFIPlugin writeSupportFiles.

	self storeString: self macAsyncFilePrimsFile	onFileNamed: 'sqMacAsyncFilePrims.c'.
	self storeString: self macBrowserPluginFile	onFileNamed: 'sqMacNSPlugin.c'.
	self storeString: self macDirectoryFile	onFileNamed: 'sqMacDirectory.c'.
	self storeString: self macJoystickAndTabletFile  onFileNamed: 'sqMacJoystickAndTablet.c'.
	self storeString: self macMinimal		onFileNamed: 'sqMacMinimal.c'.
	self storeString: self macNetworkFile		onFileNamed: 'sqMacNetwork.c'.
	self storeString: self macDragDropFile	onFileNamed: 'sqMacDragDrop.c'.
	self storeString: self macSerialAndMIDIPortFile	onFileNamed: 'sqMacSerialAndMIDIPort.c'.
	self storeString: self macSoundFile		onFileNamed: 'sqMacSound.c'.
	self storeString: self macWindowFile		onFileNamed: 'sqMacWindow.c'.
	self storeString: self macTCPFile			onFileNamed: 'MacTCP.h'.
	self storeString: self macAddressXlationFile		onFileNamed: 'AddressXlation.h'.
	self storeString: self macDNRFile					onFileNamed: 'dnr.c'.

	self storeStuffitArchive: self	 macArchiveBinaryFile
		onFileNamed: 'projectArchive.sit'.
