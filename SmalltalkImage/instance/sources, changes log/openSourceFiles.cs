openSourceFiles

	self imageName = LastImageName ifFalse:
		["Reset the author full name to blank when the image gets moved"
		LastImageName := self imageName.
		Author fullName: ''].
	FileDirectory
		openSources: self sourcesName
		andChanges: self changesName
		forImage: LastImageName.
	StandardSourceFileArray install