commandPhraseFor: commandSpec inViewer: aViewer
	| entry aRow resultType cmd names argType argTile selfTile aPhrase |
	entry _ (commandSpec copy asOrderedCollection removeFirst; yourself) asArray.
	names _ self class namedTileScriptSelectors.

	resultType _ (entry at: 1).
	cmd _ (entry at: 2).
	entry size = 2
		ifTrue:
			[aPhrase _ PhraseTileMorph new setOperator: cmd
				type: resultType
				rcvrType: #player]
		ifFalse: 
			[argType _ entry at: 3.
			aPhrase _ PhraseTileMorph new setOperator: cmd
				type: resultType
				rcvrType: #player
				argType: argType.
			argTile _ self tileForArgType: argType inViewer: aViewer.
			argTile position: aPhrase lastSubmorph position.
			aPhrase lastSubmorph addMorph: argTile].

	(names includes: cmd) ifTrue: [aPhrase userScriptSelector: cmd].
	aPhrase markAsPartsDonor.

	selfTile _ aViewer tileForSelf.
	selfTile position: aPhrase firstSubmorph position.
	aPhrase firstSubmorph addMorph: selfTile.

	aRow _ ViewerRow newRow borderWidth: 0; color: aViewer color.
	aRow elementSymbol: cmd asSymbol.

	aRow addMorphBack: (ScriptingSystem tryButtonFor: aPhrase).
	aRow addMorphBack: (Morph new extent: 4@2; beTransparent).
	aRow addMorphBack: (aViewer infoButtonFor: cmd).
	aRow addMorphBack: aPhrase.
	aRow beSticky; disableDragNDrop.

	^ aRow