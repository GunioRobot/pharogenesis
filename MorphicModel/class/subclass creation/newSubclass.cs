newSubclass
	| i className |
	i := 1.
	[className := (self name , i printString) asSymbol.
	 Smalltalk includesKey: className]
		whileTrue: [i := i + 1].

	^ self subclass: className
		instanceVariableNames: ''
		classVariableNames: ''
		poolDictionaries: ''
		category: 'Morphic-Models'