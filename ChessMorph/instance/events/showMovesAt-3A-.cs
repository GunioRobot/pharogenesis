showMovesAt: square
	| list |
	board ifNil:[^self].
	board searchAgent isThinking ifTrue:[^self].
	self squaresDo:[:m| m borderWidth: 0].
	list _ board activePlayer findValidMovesAt: square.
	list isEmpty ifTrue:[^self].
	(self atSquare: square) borderWidth: 1.
	list do:[:move|
		(self atSquare: move destinationSquare) borderWidth: 1.
	].