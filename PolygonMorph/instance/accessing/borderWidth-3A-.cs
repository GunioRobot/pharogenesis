borderWidth: anInteger

	borderColor ifNil: [borderColor _ Color black].
	borderWidth _ anInteger max: 0.
	self computeBounds