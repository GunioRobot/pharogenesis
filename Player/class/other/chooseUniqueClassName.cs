chooseUniqueClassName
	| ii className |
	ii _ BiggestSubclassNumber ifNil: [1] ifNotNil: [BiggestSubclassNumber+1].
	[className _ (self name , ii printString) asSymbol.
	 Smalltalk includesKey: className]
		whileTrue: [ii _ ii + 1].
	BiggestSubclassNumber _ ii.
	^ className	

