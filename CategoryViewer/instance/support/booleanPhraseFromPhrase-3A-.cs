booleanPhraseFromPhrase: phrase
	"Answer, if possible, a boolean-valued phrase derived from the phrase provided"

	|  retrieverOp retrieverTile |
	(phrase isKindOf: ParameterTile) ifTrue: [^ phrase booleanComparatorPhrase].
	phrase isBoolean ifTrue: [^ phrase].

	((scriptedPlayer respondsTo: #costume) 
		and:[scriptedPlayer costume isInWorld not]) ifTrue: [^ Array new].
	((retrieverTile _ phrase submorphs last) isKindOf: TileMorph) ifFalse: [^ phrase].
	retrieverOp _ retrieverTile operatorOrExpression.

	(Vocabulary vocabularyForType: phrase resultType)
		affordsCoercionToBoolean ifTrue: 
			[^ self booleanPhraseForRetrieverOfType: phrase resultType retrieverOp: retrieverOp player: phrase actualObject].

	^ phrase