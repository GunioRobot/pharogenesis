storeOn: aStream 

	aStream nextPut: $#.
	(Scanner isLiteralMultiSymbol: self)
		ifTrue: [aStream nextPutAll: self]
		ifFalse: [super storeOn: aStream].
