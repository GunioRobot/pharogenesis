initializeCastlingConstants
	CastlingDone _ 1.

	CastlingDisableKingSide _ 2.
	CastlingDisableQueenSide _ 4.
	CastlingDisableAll _ CastlingDisableQueenSide bitOr: CastlingDisableKingSide.

	CastlingEnableKingSide _ CastlingDone bitOr: CastlingDisableKingSide.
	CastlingEnableQueenSide _ CastlingDone bitOr: CastlingDisableQueenSide.
