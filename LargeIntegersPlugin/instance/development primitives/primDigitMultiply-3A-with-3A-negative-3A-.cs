primDigitMultiply: firstInteger with: secondInteger negative: neg
	| firstLarge secondLarge |
	self debugCode: [self msg: 'primDigitMultiply: firstInteger with: secondInteger negative: neg'].
	self
		primitive: 'primDigitMultiplyWithNegative'
		parameters: #(Integer Integer Boolean )
		receiver: #Oop.
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