peekInteger: offset
	self inline: true.

	self assertIsIntegerObject: (self peekLiteral: offset).
	^self integerValueOf: (self peekLiteral: offset)