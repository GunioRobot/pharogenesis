peekLiteral: offset
	self inline: true.

	^self longAt: (localIP + (offset * 4))