sizeForReturn: encoder

	(self code >= LdSelf and: [self code <= LdNil])
		ifTrue: ["short returns" ^1].
	^super sizeForReturn: encoder