phraseForReceiver: rcvr op: op arg: arg resultType: resultType

	| m argTile rcvrTile |
	arg == nil
		ifTrue:
			[m _ PhraseTileMorph new setOperator: op
				type: resultType
				rcvrType: (self typeForConstant: rcvr)]
		ifFalse:
			[m _ PhraseTileMorph new setOperator: op
				type: resultType
				rcvrType: (self typeForConstant: rcvr)
				argType: (self typeForConstant: arg).
			argTile _ self constantTile: arg.
			argTile position: m lastSubmorph position.
			m lastSubmorph addMorph: argTile].
	rcvrTile _ self constantTile: rcvr.
"	TilePadMorph makeReceiverColorOfResultType ifTrue: [rcvrTile color: m color]."
	rcvrTile position: m firstSubmorph position.
	m firstSubmorph addMorph: rcvrTile.
	^ m