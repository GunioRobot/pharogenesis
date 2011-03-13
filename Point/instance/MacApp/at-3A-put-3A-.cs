at: aCoordSymbol put: value

	(aCoordSymbol == #y or: [aCoordSymbol == #v]) ifTrue: [^y _ value]. 
	(aCoordSymbol == #x or: [aCoordSymbol == #h]) ifTrue: [^x _ value].
	^self error: 'Unknown coordinate symbol: ', aCoordSymbol printString
