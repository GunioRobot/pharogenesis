undoMove
	"Undo the last move"
	board ifNil:[^self].
	history isEmpty ifTrue:[^self].
	board undoMove: history removeLast.
