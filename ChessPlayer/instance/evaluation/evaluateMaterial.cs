evaluateMaterial
	"Compute the board's material balance, from the point of view of the side
	player.  This is an exact clone of the eval function in CHESS 4.5"
	| total diff value |
	self materialValue = opponent materialValue ifTrue:[^0]. "both sides are equal"
	total _ self materialValue + opponent materialValue.
	diff _ self materialValue - opponent materialValue.
	value _ (2400 min: diff) + 
		((diff * (12000 - total) * self numPawns) // (6400 * (self numPawns + 1))).
	^value