undoMove: move
	"Undo the given move"
	| action |
	self undoPromotion: move.
	"Apply basic move"
	action _ #(
			undoNormalMove:
			undoDoublePushMove:
			undoEnpassantMove:
			undoCastleKingSideMove:
			undoCastleQueenSideMove:
			undoResign:
			undoStaleMate:
		) at: (move moveType bitAnd: ChessMove basicMoveMask).
	self perform: action with: move.