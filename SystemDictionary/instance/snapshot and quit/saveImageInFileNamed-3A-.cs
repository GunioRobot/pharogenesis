saveImageInFileNamed: aString
	self 
		changeImageNameTo: (FileDirectory default fullNameFor: aString);
		closeSourceFiles; openSourceFiles;  "so SNAPSHOT appears in new changes file"
		saveImageSegments;
		snapshot: true andQuit: false.