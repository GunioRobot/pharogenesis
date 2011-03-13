booleanPhraseFromPhrase: phrase

	|  retrieverOp retrieverTile |
	phrase isBoolean ifTrue: [^ phrase].
	self morph isInWorld ifFalse: [^ Array new].
	((retrieverTile _ phrase submorphs last) isKindOf: TileMorph) ifFalse: [^ phrase].
	retrieverOp _ retrieverTile operatorOrExpression.

	(#(color number player) includes: phrase resultType) ifTrue:
		[^ self booleanPhraseForRetrieverOfType: phrase resultType retrieverOp: retrieverOp player: phrase actualObject].

	^ phrase