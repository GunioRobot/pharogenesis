findAttackSquaresFor: player 
	"Mark all the fields of a board that are attacked by the given player.
	The pieces attacking a field are encoded as (1 << Piece) so that we can
	record all types of pieces that attack the square."

	| move square piece attack list |
	forceCaptures := false.
	attackSquares ifNil: [attackSquares := ByteArray new: 64].
	attackSquares atAllPut: 0.
	list := self findAllPossibleMovesFor: player.
	
	[move := list next.
	move isNil] whileFalse: 
				[square := move destinationSquare.
				piece := move movingPiece.
				attack := attackSquares at: square.
				attack := attack bitOr: (1 bitShift: piece).
				attackSquares at: square put: attack].
	self recycleMoveList: list.
	^attackSquares