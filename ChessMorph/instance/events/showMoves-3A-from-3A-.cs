showMoves: evt from: aMorph
	| square |
	square _ aMorph valueOfProperty: #squarePosition.
	square ifNotNil:[^self showMovesAt: square].