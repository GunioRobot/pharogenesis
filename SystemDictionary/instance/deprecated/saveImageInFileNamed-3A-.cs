saveImageInFileNamed: aString

	self deprecated: 'Use SmalltalkImage current saveImageInFileNamed: aString'.
	SmalltalkImage current 
		changeImageNameTo: (FileDirectory default fullNameFor: aString).
	SmalltalkImage current	closeSourceFiles.
	SmalltalkImage current openSourceFiles.  "so SNAPSHOT appears in new changes file"
	SmalltalkImage current 
		saveImageSegments.
	SmalltalkImage current snapshot: true andQuit: false.