touchesAPhrase

	| outerPhrase |

	outerPhrase _ PhraseTileMorph new setOperator: #+ "temp dummy" 
				type: #boolean rcvrType: #player argType: #player.

	(outerPhrase submorphs at: 2) delete.	"operator"
	outerPhrase addMorphBack: (TileMorph new setOperator: #touchesA:).
	(outerPhrase submorphs at: 2) goBehind.		"Make it third"

	outerPhrase submorphs last addMorph: (
		TileMorph new
			setObjectRef: nil "disused parm"
			actualObject: scriptedPlayer;
			typeColor: (ScriptingSystem colorForType: #player)
	).
	^ outerPhrase