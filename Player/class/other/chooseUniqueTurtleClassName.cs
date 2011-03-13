chooseUniqueTurtleClassName
	| ii className |
	className _ self name.
	[className last isDigit] whileTrue: [className _ className copyFrom: 1 to: className size - 1].

	ii _ BiggestSubclassNumber ifNil: [1] ifNotNil: [BiggestSubclassNumber+1].
	[className _ (className , ii printString) asSymbol.
	 Smalltalk includesKey: className]
		whileTrue: [ii _ ii + 1].
	BiggestSubclassNumber _ ii.
	^ className	

