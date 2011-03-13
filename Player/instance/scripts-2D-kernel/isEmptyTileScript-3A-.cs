isEmptyTileScript: aScriptName
	"Answer the script of the given name is an empty tile script"

	| aUserScript |
	aUserScript _ self class userScriptForPlayer: self selector: aScriptName.
	aUserScript isTextuallyCoded ifTrue:
		[^ false].
	^ (aUserScript instantiatedScriptEditorForPlayer: self) isEmpty
