isEmptyTileScript: aScriptName
	| aUserScript |
	aUserScript _ self class userScriptForPlayer: self selector: aScriptName.
	aUserScript isTextuallyCoded ifTrue:
		[^ false].
	^ aUserScript instantiatedScriptEditor isEmpty
