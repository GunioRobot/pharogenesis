primDigitMultiply: secondInteger negative: neg 
	""
	| firstLarge secondLarge firstInteger |
	self debugCode: [self msg: 'primDigitMultiply: secondInteger negative: neg'].
	firstInteger _ self
		primitive: 'primDigitMultiplyNegative'
		parameters: #( Integer Boolean )
		receiver: #Integer.
	(interpreterProxy isIntegerObject: firstInteger)
		ifTrue: ["convert it to a not normalized LargeInteger"
			self remapOop: secondInteger in: [firstLarge _ self createLargeFromSmallInteger: firstInteger]]
		ifFalse: [firstLarge _ firstInteger].
	(interpreterProxy isIntegerObject: secondInteger)
		ifTrue: ["convert it to a not normalized LargeInteger"
			self remapOop: firstLarge in: [secondLarge _ self createLargeFromSmallInteger: secondInteger]]
		ifFalse: [secondLarge _ secondInteger].
	^ self
		digitMultiplyLarge: firstLarge
		with: secondLarge
		negative: neg