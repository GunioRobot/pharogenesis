canCastleQueenSide
	(castlingStatus bitAnd: CastlingEnableQueenSide) = 0 ifFalse: [^false].
	self isWhitePlayer 
		ifTrue: 
			[pieces second = 0 ifFalse: [^false].
			(pieces third) = 0 ifFalse: [^false].
			pieces fourth = 0 ifFalse: [^false].
			(opponent pieceAt: 2) = 0 ifFalse: [^false].
			(opponent pieceAt: 3) = 0 ifFalse: [^false].
			(opponent pieceAt: 4) = 0 ifFalse: [^false]]
		ifFalse: 
			[(pieces at: 58) = 0 ifFalse: [^false].
			(pieces at: 59) = 0 ifFalse: [^false].
			(pieces at: 60) = 0 ifFalse: [^false].
			(opponent pieceAt: 58) = 0 ifFalse: [^false].
			(opponent pieceAt: 59) = 0 ifFalse: [^false].
			(opponent pieceAt: 60) = 0 ifFalse: [^false]].
	^true