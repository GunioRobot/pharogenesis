fetchOffset
	self inline: true.
	^(self offsetValueOf: (self fetchLiteral)) "* 8"