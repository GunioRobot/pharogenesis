booleanPhraseForBounceOnColorOfType: retrieverType retrieverOp: retrieverOp player: aPlayer
	"Answer a boolean-valued phrase derived from a retriever (e.g. 'car's heading'); this is in order to assure that tiles laid down in a TEST area will indeed produce a boolean result"

	| outerPhrase getterPhrase receiverTile  rel finalTile |
	rel _ (Vocabulary vocabularyForType:  retrieverType) comparatorForSampleBoolean.
	outerPhrase _ PhraseTileMorph new setOperator: rel type: #Boolean rcvrType: retrieverType argType: retrieverType.
	getterPhrase _  PhraseTileMorph new setBounceOnColorOperator: retrieverOp type: retrieverType rcvrType: #Player argType: nil.
	getterPhrase submorphs third delete.
	getterPhrase submorphs second setSlotRefOperator: retrieverOp.
	"getterPhrase submorphs second setPatchDefaultTo: (scriptedPlayer defaultPatchPlayer)."
	getterPhrase submorphs first changeTableLayout.
	receiverTile _ aPlayer tileToRefer bePossessive.
	"self halt."
	receiverTile position: getterPhrase firstSubmorph position.
	getterPhrase firstSubmorph addMorph: receiverTile.

	outerPhrase firstSubmorph addMorph: getterPhrase.
	finalTile _ ScriptingSystem tileForArgType: retrieverType.	"comes with arrows"
	outerPhrase submorphs last addMorph: finalTile.
	outerPhrase submorphs second submorphs last setBalloonText: (ScriptingSystem helpStringForOperator: rel).    
	^ outerPhrase