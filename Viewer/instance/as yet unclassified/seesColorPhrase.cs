seesColorPhrase
	| outerPhrase seesColorTile |
	outerPhrase _ PhraseTileMorph new setOperator: #+ "temp dummy" 
				type: #boolean rcvrType: #player argType: #color.
	"Install (ColorSeerTile new) in middle position"
	(outerPhrase submorphs at: 2) delete.	"operator"
	seesColorTile _ TileMorph new setOperator: #seesColor:.
	outerPhrase addMorphBack: seesColorTile.
	(outerPhrase submorphs at: 2) goBehind.		"Make it third"
"	selfTile _ self tileForSelf bePossessive.	Done by caller.
	selfTile position: 1.
	outerPhrase firstSubmorph addMorph: selfTile.
"
	outerPhrase submorphs last addMorph: (ColorTileMorph new typeColor: 
		(ScriptingSystem colorForType: #color)).
	^ outerPhrase