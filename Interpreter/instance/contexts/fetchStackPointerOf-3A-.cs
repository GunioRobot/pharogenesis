fetchStackPointerOf: aContext
	"Return the stackPointer of a Context or BlockContext."
	| sp |
	self inline: true.
	sp _ self fetchPointer: StackPointerIndex ofObject: aContext.
	(self isIntegerObject: sp) ifFalse: [^0].
	^self integerValueOf: sp