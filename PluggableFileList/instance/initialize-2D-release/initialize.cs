initialize

	prompt _ 'Select File'.
	directory _ FileDirectory default.
	newFiles _ OrderedCollection new.
	fileFilterBlock _ PluggableFileList allFilesAndFoldersFileFilter.
	canAcceptBlock _ PluggableFileList fileNameSelectedAcceptBlock.
	resultBlock _ PluggableFileList pathNameResultBlock.
	validateBlock _ PluggableFileList checkExistingFileValidateBlock.
