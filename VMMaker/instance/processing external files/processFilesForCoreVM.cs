processFilesForCoreVM
	"process any cross-platform files from the crossPlatformDir and then any files relating to the core vm from the platformDirectory's vm subdirectory."
	"This is a stub ready for collecting all the filenames etc that might be needed to write a makefile. No details are yet certain."

	| vmDirName fList |
	vmDirName _ self class coreVMDirName.
	fList _ OrderedCollection new.
	{self crossPlatformDirectory directoryNamed: vmDirName.
	self platformDirectory directoryNamed: vmDirName.
	self coreVMDirectory}
		do:[:dir| fList addAll: (dir fullNamesOfAllFilesInSubtree reject:[:el| (el findString: 'CVS' startingAt: 1) ~= 0])].
	allFilesList at: 'vm' put: fList
