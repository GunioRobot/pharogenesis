writeToFileWithSymbols: shortName

	segmentName _ (shortName endsWith: '.seg')
		ifTrue: [shortName copyFrom: 1 to: shortName size - 4]
		ifFalse: [shortName].
	segmentName last isDigit ifTrue: [segmentName _ segmentName, '-'].
	self writeToFileWithSymbols.