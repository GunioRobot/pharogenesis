prepareNextMove
	"Clear enpassant square and reset any pending extra kings"
	enpassantSquare _ 0.
	castlingRookSquare = 0 ifFalse:[pieces at: castlingRookSquare put: Rook].
	castlingRookSquare _ 0.
