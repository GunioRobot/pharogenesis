newSubclass
	| i className |
	i _ 1.
	[className _ (self name , i printString) asSymbol.
	 self environment includesKey: className]
		whileTrue: [i _ i + 1].

	^ self subclass: className
		instanceVariableNames: ''
		classVariableNames: ''
		poolDictionaries: ''
		category: Object categoryForUniclasses

"Point newSubclass new"