borderWidth: anInteger

	borderColor ifNil: [borderColor _ Color black].
	borderWidth _ anInteger.
	self computeBounds