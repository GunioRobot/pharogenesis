primitiveShortAt
	"Treat the receiver, which can be indexible by either bytes or words, as an array of signed 16-bit values. Return the contents of the given index. Note that the index specifies the i-th 16-bit entry, not the i-th byte or word."

	| index rcvr sz addr value |
	index _ self stackIntegerValue: 0.
	rcvr _ self stackValue: 1.
	self success: ((self isIntegerObject: rcvr) not and: [self isWordsOrBytes: rcvr]).
	successFlag ifFalse: [ ^ nil ].
	sz _ ((self sizeBitsOf: rcvr) - BaseHeaderSize) // 2.  "number of 16-bit fields"
	self success: ((index >= 1) and: [index <= sz]).
	successFlag ifTrue: [
		addr _ rcvr + BaseHeaderSize + (2 * (index - 1)).
		value _ self cCode: '*((short int *) addr)'.
		self pop: 2.  "pop rcvr, index"
		self pushInteger: value.  "push element value"
	].