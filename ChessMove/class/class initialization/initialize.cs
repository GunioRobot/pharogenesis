initialize
	"ChessMove initialize"
	MoveNormal _ 1.
	MoveDoublePush _ 2.
	MoveCaptureEnPassant _ 3.
	MoveCastlingKingSide _ 4.
	MoveCastlingQueenSide _ 5.
	MoveResign _ 6.
	MoveStaleMate _ 7.

	BasicMoveMask _ 15.
	PromotionShift _ 4.
	ExtractPromotionShift _  0 - PromotionShift.

	EvalTypeAccurate _ 0.
	EvalTypeUpperBound _ 1.
	EvalTypeLowerBound _ 2.

	NullMove _ 0.

