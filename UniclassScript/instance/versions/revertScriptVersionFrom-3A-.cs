revertScriptVersionFrom: anEditor 
	"Let user choose which prior tile version to revert to, and revert to it"

	| aMenu chosenStampAndTileList |
	formerScriptingTiles isEmptyOrNil ifTrue: [^Beeper beep].
	chosenStampAndTileList := formerScriptingTiles size == 1 
		ifTrue: [ formerScriptingTiles first]
		ifFalse: 
			[aMenu := SelectionMenu 
						labelList: (formerScriptingTiles collect: [:e | e first])
						selections: formerScriptingTiles.
			aMenu startUp].
	chosenStampAndTileList ifNotNil: 
			[anEditor reinsertSavedTiles: chosenStampAndTileList second.
			isTextuallyCoded := false]