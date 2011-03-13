booleanPhraseForRetrieverOfType: retrieverType retrieverOp: retrieverOp player: aPlayer
	"Answer a boolean-valued phrase derived from a retriever (e.g. 'car's heading'); this is in order to assure that tiles laid down in a TEST area will indeed produce a boolean result"

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
	finalTile _ aPlayer tileForArgType: retrieverType.	"comes with arrows"
	outerPhrase submorphs last addMorph: finalTile.
	outerPhrase submorphs second submorphs last setBalloonText: (ScriptingSystem helpStringForOperator: rel).    
	^ outerPhrase