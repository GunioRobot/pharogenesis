saveImageInFileNamed: aString
	| fullImageName |
	fullImageName _ (FileDirectory default fullNameFor: aString).
	(FileDirectory default directoryNamed:(FileDirectory dirPathFor: fullImageName )) assureExistence.
	self
		changeImageNameTo: fullImageName;
		closeSourceFiles;
		openSourceFiles;  "so SNAPSHOT appears in new changes file"
		saveImageSegments;
		snapshot: true andQuit: false