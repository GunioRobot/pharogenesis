createFromText: aString

	(aString class = String) ifFalse:
		[^self error: 'TextType Data Not From String'].
	(self 
		primAECreateDesc: (DescType of: 'TEXT')
		from: aString) isZero ifTrue: [^self].
	self error: 'failed to create aeDesc'.
	^nil