primDigitDiv: secondInteger negative: neg 
	"Answer the result of dividing firstInteger by secondInteger.  Fail if      
	parameters are not integers or secondInteger is zero."
	| firstAsLargeInteger secondAsLargeInteger firstInteger |
	self debugCode: [self msg: 'primDigitDiv: secondInteger negative: neg'].
	firstInteger _ self
				primitive: 'primDigitDivNegative'
				parameters: #(Integer Boolean )
				receiver: #Integer.
	"Coerce SmallIntegers to corresponding (not normalized) large integers    
	  and check for zerodivide."
	(interpreterProxy isIntegerObject: firstInteger)
		ifTrue: ["convert to LargeInteger"
			self remapOop: secondInteger in: [firstAsLargeInteger _ self createLargeFromSmallInteger: firstInteger]]
		ifFalse: [firstAsLargeInteger _ firstInteger].
	(interpreterProxy isIntegerObject: secondInteger)
		ifTrue: 
			["check for zerodivide and convert to LargeInteger"
			(interpreterProxy integerValueOf: secondInteger)
				= 0 ifTrue: [^ interpreterProxy primitiveFail].
			self remapOop: firstAsLargeInteger in: [secondAsLargeInteger _ self createLargeFromSmallInteger: secondInteger]]
		ifFalse: [secondAsLargeInteger _ secondInteger].
	^ self
		digitDivLarge: firstAsLargeInteger
		with: secondAsLargeInteger
		negative: neg