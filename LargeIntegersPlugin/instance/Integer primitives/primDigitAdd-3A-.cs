primDigitAdd: secondInteger
	| firstLarge secondLarge firstInteger |
	self debugCode: [self msg: 'primDigitAdd: secondInteger'].
	firstInteger _ self
				primitive: 'primDigitAdd'
				parameters: #(Integer )
				receiver: #Integer.
	(interpreterProxy isIntegerObject: firstInteger)
		ifTrue: ["convert it to a not normalized LargeInteger"
			self remapOop: secondInteger in: [firstLarge _ self createLargeFromSmallInteger: firstInteger]]
		ifFalse: [firstLarge _ firstInteger].
	(interpreterProxy isIntegerObject: secondInteger)
		ifTrue: ["convert it to a not normalized LargeInteger"
			self remapOop: firstLarge in: [secondLarge _ self createLargeFromSmallInteger: secondInteger]]
		ifFalse: [secondLarge _ secondInteger].
	^ self digitAddLarge: firstLarge with: secondLarge