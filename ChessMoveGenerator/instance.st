Object
	subclass: #ChessMoveGenerator
	instanceVariableNames:
		'myPlayer myPieces itsPieces castlingStatus enpassantSquare forceCaptures moveList firstMoveIndex lastMoveIndex streamList streamListIndex attackSquares kingAttack'
	classVariableNames: 'EmptyPieceMap'
	poolDictionaries: 'ChessConstants'
	category: 'Morphic-Games-Chess'