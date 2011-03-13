booleanPhraseForRetrieverOfType: retrieverType retrieverOp: retrieverOp player: aPlayer

	| outerPhrase getterPhrase receiverTile  rel finalTile |
	rel _ (retrieverType == #number)
		ifTrue:		[#<]
		ifFalse:		[#=].
	outerPhrase _ PhraseTileMorph new setOperator: rel type: #boolean rcvrType: retrieverType argType: retrieverType.
	getterPhrase _  PhraseTileMorph new setOperator: retrieverOp type: retrieverType rcvrType: #player.
	getterPhrase submorphs last setSlotRefOperator: (Utilities inherentSelectorForGetter: retrieverOp).
	receiverTile _ (self tileForPlayer: aPlayer) bePossessive.
	receiverTile position: getterPhrase firstSubmorph position.
	getterPhrase firstSubmorph addMorph: receiverTile.

	outerPhrase firstSubmorph addMorph: getterPhrase.
	finalTile _ self tileForArgType: retrieverType.
	retrieverType == #number ifTrue: [finalTile addArrows].
	outerPhrase submorphs last addMorph: finalTile.
	^ outerPhrase