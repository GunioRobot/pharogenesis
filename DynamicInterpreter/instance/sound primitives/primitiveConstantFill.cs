primitiveConstantFill
	"Fill the receiver, which must be an indexable bytes or words objects, with the given integer value."

	| fillValue rcvr rcvrIsBytes end i |
	fillValue _ self positive32BitValueOf: self stackTop. 
	rcvr _ self stackValue: 1.
	self success: (self isWordsOrBytes: rcvr).
	rcvrIsBytes _ self isBytes: rcvr.
	rcvrIsBytes ifTrue: [
		self success: ((fillValue >= 0) and: [fillValue <= 255]).
	].
	successFlag ifTrue: [
		end _ rcvr + (self sizeBitsOf: rcvr).
		i _ rcvr + BaseHeaderSize.
		rcvrIsBytes ifTrue: [
			[i < end] whileTrue: [
				self byteAt: i put: fillValue.
				i _ i + 1.
			].
		] ifFalse: [
			[i < end] whileTrue: [
				self longAt: i put: fillValue.
				i _ i + 4.
			].
		].
		self pop: 1.  "pop fillValue; leave rcvr on stack"
	].
