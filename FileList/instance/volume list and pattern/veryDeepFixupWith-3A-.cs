veryDeepFixupWith: deepCopier
	super veryDeepFixupWith: deepCopier.
	volListIndex _ 1.
	self directory: FileDirectory default.
	self updateFileList