getFilePathNameDialog

	^(self new)
		validateBlock: PluggableFileList alwaysValidateBlock;
		yourself