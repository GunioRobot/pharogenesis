edgesWithoutTag: aSymbol 
	^ self edges reject: [:edge | edge testTag: aSymbol]