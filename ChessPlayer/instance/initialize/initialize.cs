initialize
	"ChessPlayer initialize"
	pieces _ ByteArray new: 64.
	materialValue _ 0.
	positionalValue _ 0.
	numPawns _ 0.
	enpassantSquare _ 0.
	castlingRookSquare _ 0.
	castlingStatus _ 0.