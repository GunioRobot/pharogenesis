processFilesForCoreVM
	"When using a copying version of VMMaker, copy any cross-platform files from the crossPlatformDir and then copy any files relating to the core vm from the platformDirectory's vm subdirectory."
	super processFilesForCoreVM.

	"Is there a crossPlatformDirectory subdirectory called 'vmDirName'?"
	self copyCrossPlatformVMFiles.

	"Is there a platformDirectory subdirectory called 'vmDirName'?"
	self copyPlatformVMFiles
