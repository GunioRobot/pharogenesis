copyCrossPlatformVMFiles
	| srcDir targetDir vmDirName |
	vmDirName _ self class coreVMDirName.

	"Is there a crossPlatformDirectory subdirectory called 'vmDirName'?"
	(self crossPlatformDirectory directoryExists: vmDirName)
		ifTrue: [srcDir _ self crossPlatformDirectory directoryNamed: vmDirName.
			targetDir _ self coreVMDirectory.
			self copyFilesFromSourceDirectory: srcDir toTargetDirectory: targetDir]