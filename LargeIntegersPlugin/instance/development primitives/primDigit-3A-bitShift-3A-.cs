primDigit: anInteger bitShift: shiftCount 
	| rShift aLarge |
	self debugCode: [self msg: 'primDigit: anInteger bitShift: shiftCount'].
	self
		primitive: '_primDigitBitShift'
		parameters: #(Integer SmallInteger )
		receiver: #Oop.
	(interpreterProxy isIntegerObject: anInteger)
		ifTrue: ["convert it to a not normalized LargeInteger"
			aLarge _ self createLargeFromSmallInteger: anInteger]
		ifFalse: [aLarge _ anInteger].
	shiftCount >= 0
		ifTrue: [^ self bytes: aLarge Lshift: shiftCount]
		ifFalse: 
			[rShift _ 0 - shiftCount.
			^ self normalize: (self
					bytes: aLarge
					Rshift: (rShift bitAnd: 7)
					bytes: (rShift bitShift: -3)
					lookfirst: (self byteSizeOfBytes: aLarge))]