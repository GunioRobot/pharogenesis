generateMainVM
"generate the interp, internal plugins and exports"

	self generateInterpreterFile;
		processFilesForCoreVM;
		processAssortedFiles;
		generateInternalPlugins;
		generateExportsFile