update: aSymbol
	aSymbol = #close
		ifTrue: [^self controller close].
	^super update: aSymbol