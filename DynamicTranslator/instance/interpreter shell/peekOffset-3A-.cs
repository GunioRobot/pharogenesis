peekOffset: offset
	self inline: true.

	^(self offsetValueOf: (self peekLiteral: offset)) "* 8"