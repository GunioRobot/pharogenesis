compareWithFilesInFolder: folderName
	"InterpreterSupportCode compareWithFilesInFolder: 'Black Uhuru:Desktop Folder:CW Test Project'"

	| dir |
	dir _ FileDirectory on: folderName.

	(dir readOnlyFileNamed: 'projectArchive.sit') binary contentsOfEntireFile =
	InterpreterSupportCode archiveBinaryFileBytes
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

	(dir readOnlyFileNamed: 'sqMachDep.h') contentsOfEntireFile =
	InterpreterSupportCode squeakMachDepFile
		ifFalse: [self inform: 'File sqMachDep.h differs from the version stored in this image.'].

	(dir readOnlyFileNamed: 'sqPlatformSpecific.h') contentsOfEntireFile =
	InterpreterSupportCode squeakPlatSpecFile
		ifFalse: [self inform: 'File sqPlatformSpecific.h differs from the version stored in this image.'].

	(dir readOnlyFileNamed: 'sqFilePrims.c') contentsOfEntireFile =
	InterpreterSupportCode squeakFilePrimsFile
		ifFalse: [self inform: 'File sqFilePrims.c differs from the version stored in this image.'].

	(dir readOnlyFileNamed: 'sqMacDirectory.c') contentsOfEntireFile =
	InterpreterSupportCode macDirectoryFile
		ifFalse: [self inform: 'File sqMacDirectory.c differs from the version stored in this image.'].

	(dir readOnlyFileNamed: 'sqMacJoystick.c') contentsOfEntireFile =
	InterpreterSupportCode macJoystickFile
		ifFalse: [self inform: 'File sqMacJoystick.c differs from the version stored in this image.'].

	(dir readOnlyFileNamed: 'sqMacNetwork.c') contentsOfEntireFile =
	InterpreterSupportCode macNetworkFile
		ifFalse: [self inform: 'File sqMacNetwork.c differs from the version stored in this image.'].

	(dir readOnlyFileNamed: 'sqMacSound.c') contentsOfEntireFile =
	InterpreterSupportCode macSoundFile
		ifFalse: [self inform: 'File sqMacSound.c differs from the version stored in this image.'].

	(dir readOnlyFileNamed: 'sqMacWindow.c') contentsOfEntireFile =
	InterpreterSupportCode macWindowFile
		ifFalse: [self inform: 'File sqMacWindow.c differs from the version stored in this image.'].

	(dir readOnlyFileNamed: 'sqOldSoundPrims.c') contentsOfEntireFile =
	InterpreterSupportCode squeakOldSoundPrimsFile
		ifFalse: [self inform: 'File sqOldSoundPrims.c differs from the version stored in this image.'].

	dir _ dir directoryNamed: 'MacTCP'.
	(dir readOnlyFileNamed: 'MacTCP.h') contentsOfEntireFile =
	InterpreterSupportCode macTCPFile
		ifFalse: [self inform: 'File MacTCP.h differs from the version stored in this image.'].

	(dir readOnlyFileNamed: 'AddressXlation.h') contentsOfEntireFile =
	InterpreterSupportCode macAddressXlationFile
		ifFalse: [self inform: 'File AddressXlation.h differs from the version stored in this image.'].

	(dir readOnlyFileNamed: 'dnr.c') contentsOfEntireFile =
	InterpreterSupportCode macDNRFile
		ifFalse: [self inform: 'File dnr.c differs from the version stored in this image.'].

