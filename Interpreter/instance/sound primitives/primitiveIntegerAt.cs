primitiveIntegerAt
	"Return the 32bit signed integer contents of a words receiver"
	| index rcvr sz addr value |
	index _ self stackIntegerValue: 0.
	rcvr _ self stackValue: 1.
	(self isWords: rcvr) ifFalse: [^ self success: false].
	sz _ self lengthOf: rcvr. "number of fields"
	self success: (index >= 1 and: [index <= sz]).
	successFlag
		ifTrue: [addr _ rcvr + BaseHeaderSize - 4 + (index * 4).
			"for zero indexing"
			value _ self cCode: '*((int *) addr)' inSmalltalk: [self integerAt: addr].
			self pop: 2.
			"pop rcvr, index"
			"push element value"
			(self isIntegerValue: value)
				ifTrue: [self pushInteger: value]
				ifFalse: [self push: (self signed32BitIntegerFor: value)]]