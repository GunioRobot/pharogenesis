edgesWithTag: aSymbol
	^ self edges select: [:edge| edge testTag: aSymbol]