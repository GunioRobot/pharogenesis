parsePrimitiveOrExternalCall
	currentTokenFirst = $< ifFalse: [^nil].
	self scanPast: #primitiveOrExternalCallStart.
	currentToken = 'primitive:' 
		ifTrue: [
			self rangeType: #primitive.
			^self parsePrimitive].
	self isTokenExternalFunctionCallingConvention 
		ifTrue: [
			self rangeType: #externalFunctionCallingConvention.
			^self parseExternalCall].
	self error	": 'Invalid External Function Calling convention'"