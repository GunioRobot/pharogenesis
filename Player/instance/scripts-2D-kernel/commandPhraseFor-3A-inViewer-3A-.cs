"Translate commandSpec into a PhraseTileMorph.  Put appropriate balloon help into the phrase"

commandPhraseFor: commandSpec inViewer: aViewer

	| aRow resultType cmd names argType argTile selfTile aPhrase balloonTextSelector stat inst ut aDocString |
	names _ self class namedTileScriptSelectors.

	resultType _ (commandSpec at: 1).
	cmd _ (commandSpec at: 2).
	(ut _ self isUniversalTiles)
		ifTrue:
			[aPhrase _ (CategoryViewer new) newTilesFor: self command: commandSpec]
		ifFalse: [commandSpec size = 3
			ifTrue:
				[aPhrase _ PhraseTileMorph new setOperator: cmd
					type: resultType
					rcvrType: #player]
			ifFalse: "commandSpec size is four"
				[argType _ commandSpec at: 4.
				aPhrase _ PhraseTileMorph new setOperator: cmd
					type: resultType
					rcvrType: #player
					argType: argType.
				argTile _ self tileForArgType: argType inViewer: aViewer.
				argTile position: aPhrase lastSubmorph position.
				aPhrase lastSubmorph addMorph: argTile]].

	(self slotInfo includesKey: cmd)
		ifTrue: [balloonTextSelector _ #userSlot].

	(self belongsToUniClass and: [self class includesSelector: cmd])
		ifTrue:
			[aDocString _ (self class userScriptForPlayer: self selector: cmd) documentationOrNil.
			aDocString ifNotNil:
					[aPhrase submorphs second setBalloonText: aDocString]
				ifNil:
					[balloonTextSelector _ #userScript]].

	(ut ifTrue: [aPhrase submorphs second] ifFalse: [aPhrase operatorTile]) balloonTextSelector: 
			(balloonTextSelector ifNil: [cmd]).
	aPhrase markAsPartsDonor.
	cmd == #emptyScript ifTrue:
		[aPhrase setProperty: #newPermanentScript toValue: true.
		aPhrase setProperty: #newPermanentPlayer toValue: self.
		aPhrase submorphs second setBalloonText: 
'drag and drop to 
add a new script'].

	ut ifFalse: [
		selfTile _ aViewer tileForSelf.
		selfTile position: aPhrase firstSubmorph position.
		aPhrase firstSubmorph addMorph: selfTile].

	aRow _ ViewerRow newRow borderWidth: 0; color: aViewer color.
	aRow elementSymbol: cmd asSymbol.

	aRow addMorphBack: (ScriptingSystem tryButtonFor: aPhrase).
	aRow addMorphBack: (Morph new extent: 4@2; beTransparent).
	aRow addMorphBack: (aViewer infoButtonFor: cmd).
	aRow addMorphBack: aPhrase.
	(names includes: cmd) ifTrue:
		[aPhrase userScriptSelector: cmd.
		aPhrase beTransparent.
		aRow addMorphBack: AlignmentMorph newVariableTransparentSpacer.
		aRow addMorphBack: (stat _ (inst _ self scriptInstantiationForSelector: cmd) statusControlMorph).
		inst updateStatusMorph: stat].

	aRow beSticky; disableDragNDrop.

	^ aRow