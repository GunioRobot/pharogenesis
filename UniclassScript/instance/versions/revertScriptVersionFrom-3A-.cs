revertScriptVersionFrom: anEditor
	"Let user choose which prior tile version to revert to, and revert to it"

	| aMenu chosenStampAndTileList |
	formerScriptingTiles isEmptyOrNil ifTrue: [^ self beep].
	formerScriptingTiles size == 1
		ifTrue:
			[chosenStampAndTileList _ formerScriptingTiles first]
		ifFalse:
			[aMenu _ SelectionMenu labelList: (formerScriptingTiles collect: [:e | e first])
				selections: formerScriptingTiles.
			chosenStampAndTileList _ aMenu startUp].
	chosenStampAndTileList ifNotNil:
		[anEditor reinsertSavedTiles: chosenStampAndTileList second.
		isTextuallyCoded _ false]