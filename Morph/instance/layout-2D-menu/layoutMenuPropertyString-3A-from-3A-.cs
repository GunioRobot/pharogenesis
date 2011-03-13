layoutMenuPropertyString: aSymbol from: currentSetting
	| index |
	^String streamContents:[:s|
		s nextPutAll: (aSymbol == currentSetting ifTrue:['<on>'] ifFalse:['<off>']).
		index _ 1.
		aSymbol keysAndValuesDo:[:idx :ch|
			ch isUppercase ifTrue:[
				s nextPutAll: (aSymbol copyFrom: index to: idx-1) asLowercase.
				s nextPutAll:' '.
				index _ idx]].
		index < aSymbol size ifTrue:[s nextPutAll: (aSymbol copyFrom: index to: aSymbol size) asLowercase]].
