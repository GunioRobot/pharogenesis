update: aSymbol
	(aSymbol = #volumeListIndex or: [aSymbol = #fileListIndex])
		ifTrue: [self updateAcceptButton].
	^super update: aSymbol