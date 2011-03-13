parseChunk: aString
	| tokens |
	tokens := Scanner new scanTokens: aString.
	classRef := OBClassReference named: tokens first.
	tokens second = #class
		ifTrue: [classRef beMeta.
				category := tokens fourth.
				stamp := tokens sixth]
		ifFalse: [category := tokens third.
				tokens size > 3 ifTrue: [stamp := tokens fifth]].
	tokens size > 6 ifTrue: [prior := tokens last].