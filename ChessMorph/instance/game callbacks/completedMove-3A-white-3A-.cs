completedMove: aMove white: aBool
	board ifNil:[^self].
	history addLast: aMove.
	self validateGamePosition.