wantsDroppedMorph: aMorph event: anEvent
	| sourceSquare destSquare |
	(aMorph valueOfProperty: #chessBoard) == self ifFalse:[^false].
	board ifNil:[^true].
	sourceSquare _ aMorph valueOfProperty: #chessBoardSourceSquare.
	destSquare _ self asSquare: aMorph bounds center.
	destSquare ifNil:[^false].
	^board activePlayer isValidMoveFrom: sourceSquare to: destSquare