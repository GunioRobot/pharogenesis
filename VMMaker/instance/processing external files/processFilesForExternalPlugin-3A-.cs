processFilesForExternalPlugin: plugin 
	"process any files relating to the external plugin.
	This also provides a  stub ready for collecting all the filenames etc that might be needed to write a makefile, carefully weeding out any CVS related files. No details are yet certain."
	|fList|
	fList _ OrderedCollection new.
	{self crossPlatformPluginsDirectory directoryNamed:  plugin moduleName.
	self platformPluginsDirectory directoryNamed:  plugin moduleName.
	self externalPluginsDirectoryFor: plugin}
		do:[:dir| fList addAll: (dir fullNamesOfAllFilesInSubtree reject:[:el| (el findString: 'CVS' startingAt: 1) ~= 0])].
	allFilesList at: plugin moduleName put: fList