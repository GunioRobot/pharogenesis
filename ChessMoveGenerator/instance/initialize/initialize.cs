initialize
	EmptyPieceMap ifNil:[
		EmptyPieceMap _ ByteArray new: 256.
		2 to: 7 do:[:i| EmptyPieceMap at: i put: 1]].

	streamList _ Array new: 100. "e.g., 100 plies"
	1 to: streamList size do:[:i| streamList at: i put: (ChessMoveList on: #())].
	moveList _ Array new: streamList size * 30. "avg. 30 moves per ply"
	1 to: moveList size do:[:i| moveList at: i put: (ChessMove new init)].
	firstMoveIndex _ lastMoveIndex _ streamListIndex _ 0.