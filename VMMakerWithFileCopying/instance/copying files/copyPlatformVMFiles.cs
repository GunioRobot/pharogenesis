copyPlatformVMFiles
	| srcDir targetDir vmDirName |
	vmDirName _ self class coreVMDirName.

	"Is there a platformDirectory subdirectory called 'vmDirName'?"
	(self platformDirectory directoryExists: vmDirName)
		ifTrue: [srcDir _ self platformDirectory directoryNamed: vmDirName.
			targetDir _ self coreVMDirectory.
			self copyFilesFromSourceDirectory: srcDir toTargetDirectory: targetDir]