compareWithFilesInFolder: folderName
	"InterpreterSupportCode compareWithFilesInFolder: 'Tosh:Desktop Folder:Squeak VM Project'"

	| dir |
	dir _ FileDirectory on: folderName.

	(dir readOnlyFileNamed: 'projectArchive.sit') binary contentsOfEntireFile =
	InterpreterSupportCode macArchiveBinaryFile asByteArray
		ifFalse: [self inform: 'File projectArchive.sit differs from the version stored in this image.'].

	(dir readOnlyFileNamed: 'readme') contentsOfEntireFile =
	InterpreterSupportCode readmeFile
		ifFalse: [self inform: 'File readme differs from the version stored in this image.'].

	(dir readOnlyFileNamed: 'sq.h') contentsOfEntireFile =
	InterpreterSupportCode squeakHeaderFile
		ifFalse: [self inform: 'File sq.h differs from the version stored in this image.'].

	(dir readOnlyFileNamed: 'sqConfig.h') contentsOfEntireFile =
	InterpreterSupportCode squeakConfigFile
		ifFalse: [self inform: 'File sqConfig.h differs from the version stored in this image.'].

	(dir readOnlyFileNamed: 'platform.exports') contentsOfEntireFile =
	InterpreterSupportCode squeakPlatformExportsFile
		ifFalse: [self inform: 'File platform.exports differs from the version stored in this image.'].

	(dir readOnlyFileNamed: 'sqPlatformSpecific.h') contentsOfEntireFile =
	InterpreterSupportCode squeakPlatSpecFile
		ifFalse: [self inform: 'File sqPlatformSpecific.h differs from the version stored in this image.'].

	(dir readOnlyFileNamed: 'sqFilePrims.c') contentsOfEntireFile =
	InterpreterSupportCode squeakFilePrimsFile
		ifFalse: [self inform: 'File sqFilePrims.c differs from the version stored in this image.'].

	(dir readOnlyFileNamed: 'sqMacAsyncFilePrims.c') contentsOfEntireFile =
	InterpreterSupportCode macAsyncFilePrimsFile
		ifFalse: [self inform: 'File sqMacAsyncFilePrims.c differs from the version stored in this image.'].

	(dir readOnlyFileNamed: 'sqMacNSPlugin.c') contentsOfEntireFile =
	InterpreterSupportCode macBrowserPluginFile
		ifFalse: [self inform: 'File sqMacNSPlugin.c differs from the version stored in this image.'].

	(dir readOnlyFileNamed: 'sqMacDirectory.c') contentsOfEntireFile =
	InterpreterSupportCode macDirectoryFile
		ifFalse: [self inform: 'File sqMacDirectory.c differs from the version stored in this image.'].

	(dir readOnlyFileNamed: 'sqMacDragDrop.c') contentsOfEntireFile =
	InterpreterSupportCode macDragDropFile
		ifFalse: [self inform: 'File sqMacDragDrop.c differs from the version stored in this image.'].

	(dir readOnlyFileNamed: 'sqMacJoystickAndTablet.c') contentsOfEntireFile =
	InterpreterSupportCode macJoystickAndTabletFile
		ifFalse: [self inform: 'File sqMacJoystickAndTablet.c differs from the version stored in this image.'].

	(dir readOnlyFileNamed: 'sqMacMinimal.c') contentsOfEntireFile =
	InterpreterSupportCode macMinimal
		ifFalse: [self inform: 'File sqMacMinimal.c differs from the version stored in this image.'].

	(dir readOnlyFileNamed: 'sqMacNetwork.c') contentsOfEntireFile =
	InterpreterSupportCode macNetworkFile
		ifFalse: [self inform: 'File sqMacNetwork.c differs from the version stored in this image.'].

	(dir readOnlyFileNamed: 'sqMacSerialAndMIDIPort.c') contentsOfEntireFile =
	InterpreterSupportCode macSerialAndMIDIPortFile
		ifFalse: [self inform: 'File sqMacSerialAndMIDIPort.c differs from the version stored in this image.'].

	(dir readOnlyFileNamed: 'sqMacSound.c') contentsOfEntireFile =
	InterpreterSupportCode macSoundFile
		ifFalse: [self inform: 'File sqMacSound.c differs from the version stored in this image.'].

	(dir readOnlyFileNamed: 'sqMacWindow.c') contentsOfEntireFile =
	InterpreterSupportCode macWindowFile
		ifFalse: [self inform: 'File sqMacWindow.c differs from the version stored in this image.'].

	(dir readOnlyFileNamed: 'sqNamedPrims.c') contentsOfEntireFile =
	InterpreterSupportCode squeakNamedPrimsFile
		ifFalse: [self inform: 'File sqNamedPrims.c differs from the version stored in this image.'].

	(dir readOnlyFileNamed: 'sqVirtualMachine.h') contentsOfEntireFile =
	InterpreterSupportCode squeakVirtualMachineHeaderFile
		ifFalse: [self inform: 'File sqVirtualMachine.h differs from the version stored in this image.'].

	(dir readOnlyFileNamed: 'sqVirtualMachine.c') contentsOfEntireFile =
	InterpreterSupportCode squeakVirtualMachineFile
		ifFalse: [self inform: 'File sqVirtualMachine.c differs from the version stored in this image.'].

	(dir readOnlyFileNamed: 'MacTCP.h') contentsOfEntireFile =
	InterpreterSupportCode macTCPFile
		ifFalse: [self inform: 'File MacTCP.h differs from the version stored in this image.'].

	(dir readOnlyFileNamed: 'AddressXlation.h') contentsOfEntireFile =
	InterpreterSupportCode macAddressXlationFile
		ifFalse: [self inform: 'File AddressXlation.h differs from the version stored in this image.'].

	(dir readOnlyFileNamed: 'dnr.c') contentsOfEntireFile =
	InterpreterSupportCode macDNRFile
		ifFalse: [self inform: 'File dnr.c differs from the version stored in this image.'].
