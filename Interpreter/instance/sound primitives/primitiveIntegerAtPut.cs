primitiveIntegerAtPut
	"Return the 32bit signed integer contents of a words receiver"
	| index rcvr sz addr value valueOop |
	valueOop _ self stackTop.
	index _ self stackIntegerValue: 1.
	rcvr _ self stackValue: 2.
	(self isWords: rcvr) ifFalse: [^ self success: false].
	sz _ self lengthOf: rcvr. "number of fields"
	(index >= 1 and: [index <= sz])
		ifFalse: [^ self success: false].
	(self isIntegerObject: valueOop)
		ifTrue: [value _ self integerValueOf: valueOop]
		ifFalse: [value _ self signed32BitValueOf: valueOop].
	successFlag
		ifTrue: [addr _ rcvr + BaseHeaderSize - 4 + (index * 4).
			"for zero indexing"
			value _ self cCode: '*((int *) addr) = value' inSmalltalk: [self integerAt: addr put: value].
			self pop: 3 thenPush: valueOop]