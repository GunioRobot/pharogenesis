emitForReturn: stack on: strm

	(self code >= LdSelf and: [self code <= LdNil])
		ifTrue: 
			["short returns"
			strm nextPut: EndMethod - 4 + (self code - LdSelf).
			stack push: 1 "doesnt seem right"]
		ifFalse: 
			[super emitForReturn: stack on: strm]