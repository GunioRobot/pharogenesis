undoMove: aMove white: aBool
	board ifNil:[^self].
	redoList addLast: aMove.
	self validateGamePosition.