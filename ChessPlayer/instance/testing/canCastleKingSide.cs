canCastleKingSide
	(castlingStatus bitAnd: CastlingEnableKingSide) = 0 ifFalse: [^false].
	self isWhitePlayer 
		ifTrue: 
			[(pieces sixth) = 0 ifFalse: [^false].
			pieces seventh = 0 ifFalse: [^false].
			(opponent pieceAt: 6) = 0 ifFalse: [^false].
			(opponent pieceAt: 7) = 0 ifFalse: [^false]]
		ifFalse: 
			[(pieces at: 62) = 0 ifFalse: [^false].
			(pieces at: 63) = 0 ifFalse: [^false].
			(opponent pieceAt: 62) = 0 ifFalse: [^false].
			(opponent pieceAt: 63) = 0 ifFalse: [^false]].
	^true