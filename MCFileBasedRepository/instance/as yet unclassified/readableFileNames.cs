readableFileNames
	^ self allFileNames select: [:ea | self canReadFileNamed: ea]