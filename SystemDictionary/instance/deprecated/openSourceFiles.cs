openSourceFiles
	
	self deprecated: 'Use SmalltalkImage current lastQuitLogPosition'.
	
	SmalltalkImage current imageName = LastImageName ifFalse:
		["Reset the author initials to blank when the image gets moved"
		LastImageName _ SmalltalkImage current imageName.
		Utilities setAuthorInitials: ''].
	FileDirectory
		openSources: SmalltalkImage current sourcesName
		andChanges: SmalltalkImage current changesName
		forImage: LastImageName.
	StandardSourceFileArray install