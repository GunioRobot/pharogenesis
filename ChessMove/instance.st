Object
	subclass: #ChessMove
	instanceVariableNames: 'movingPiece capturedPiece sourceSquare destinationSquare type value bestMove'
	classVariableNames:
		'BasicMoveMask EvalTypeAccurate EvalTypeLowerBound EvalTypeUpperBound ExtractPromotionShift MoveCaptureEnPassant MoveCaptureOrdinary MoveCastlingKingSide MoveCastlingQueenSide MoveDoublePush MoveNormal MovePromotionBishop MovePromotionKnight MovePromotionQueen MovePromotionRook MoveResign MoveStaleMate NoPromotionMask NullMove PromotionMask PromotionShift'
	poolDictionaries: ''
	category: 'Morphic-Games-Chess'