applyMove: move
	"Apply the given move"
	| action |
	"Apply basic move"
	action _ #(
			applyNormalMove:
			applyDoublePushMove:
			applyEnpassantMove:
			applyCastleKingSideMove:
			applyCastleQueenSideMove:
			applyResign:
			applyStaleMate:
		) at: (move moveType bitAnd: ChessMove basicMoveMask).
	self perform: action with: move.

	"Promote if necessary"
	self applyPromotion: move.

	"Maintain castling status"
	self updateCastlingStatus: move.
