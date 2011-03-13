phraseForCommandFrom: aMethodInterface
	"Answer a phrase for the non-slot-like command represented by aMethodInterface - classic tiles"

	| aRow resultType cmd names argType argTile selfTile aPhrase balloonTextSelector stat inst aDocString universal tileBearingHelp |
	aDocString _ aMethodInterface documentation.
	aDocString = 'no help available' ifTrue: [aDocString _ nil].
	names _ scriptedPlayer class namedTileScriptSelectors.

	resultType _ aMethodInterface resultType.
	cmd _ aMethodInterface selector.
	(universal _ scriptedPlayer isUniversalTiles)
		ifTrue:
			[aPhrase _ scriptedPlayer universalTilesForInterface: aMethodInterface]
		ifFalse: [cmd numArgs == 0
			ifTrue:
				[aPhrase _ PhraseTileMorph new vocabulary: self currentVocabulary.
				aPhrase setOperator: cmd
					type: resultType
					rcvrType: #Player]
			ifFalse:
				["only one arg supported in classic tiles, so if this is fed
				with a selector with > 1 arg, results will be very strange"
				argType _ aMethodInterface typeForArgumentNumber: 1.
				aPhrase _ PhraseTileMorph new vocabulary: self currentVocabulary.
				(self isSpecialPatchReceiver: scriptedPlayer and: cmd) ifTrue: [
					aPhrase setOperator: cmd
						type: resultType
						rcvrType: #Patch
						argType: argType.
				] ifFalse: [
					aPhrase setOperator: cmd
						type: resultType
						rcvrType: #Player
						argType: argType.
				].
				(self isSpecialPatchCase: scriptedPlayer and: cmd) ifTrue: [
					argTile _ (Vocabulary vocabularyForType: argType) defaultArgumentTileFor: scriptedPlayer.
				] ifFalse: [
					argTile _ ScriptingSystem tileForArgType: argType.
				].
				(#(bounce: wrap:) includes: cmd) ifTrue:
					["help for the embattled bj"
					argTile setLiteral: 'silence'; updateLiteralLabel].
				argTile position: aPhrase lastSubmorph position.
				aPhrase lastSubmorph addMorph: argTile]].

	(scriptedPlayer slotInfo includesKey: cmd)
		ifTrue: [balloonTextSelector _ #userSlot].

	(scriptedPlayer belongsToUniClass and: [scriptedPlayer class includesSelector: cmd])
		ifTrue:
			[aDocString ifNil:
				[aDocString _ (scriptedPlayer class userScriptForPlayer: scriptedPlayer selector: cmd) documentation].
			aDocString ifNil:
				[balloonTextSelector _ #userScript]].

	tileBearingHelp _ universal ifTrue: [aPhrase submorphs second] ifFalse: [aPhrase operatorTile]. 
	aDocString
		ifNotNil:
			[tileBearingHelp setBalloonText: aDocString]
		ifNil:
			[balloonTextSelector ifNil:
				[tileBearingHelp setProperty: #inherentSelector toValue: cmd.
				balloonTextSelector _ #methodComment].
			tileBearingHelp balloonTextSelector: balloonTextSelector].
	aPhrase markAsPartsDonor.
	cmd == #emptyScript ifTrue:
		[aPhrase setProperty: #newPermanentScript toValue: true.
		aPhrase setProperty: #newPermanentPlayer toValue: scriptedPlayer.
		aPhrase submorphs second setBalloonText: 
'drag and drop to 
add a new script' translated].

	universal ifFalse:
		[selfTile _ self tileForSelf.
		selfTile position: aPhrase firstSubmorph position.
		aPhrase firstSubmorph addMorph: selfTile].

	aRow _ ViewerLine newRow borderWidth: 0; color: self color.
	aRow elementSymbol: cmd asSymbol.

	aRow addMorphBack: (ScriptingSystem tryButtonFor: aPhrase).
	aRow addMorphBack: (Morph new extent: 2@2; beTransparent).
	aRow addMorphBack: (self infoButtonFor: cmd).
	aRow addMorphBack: aPhrase.
	aPhrase on: #mouseEnter send: #addCommandFeedback to: aRow.
	aPhrase on: #mouseLeave send: #removeHighlightFeedback to: aRow.
	aPhrase on: #mouseLeaveDragging send: #removeHighlightFeedback to: aRow.

	(names includes: cmd) ifTrue:
		[aPhrase userScriptSelector: cmd.
		cmd numArgs == 0 ifTrue:
			[aPhrase beTransparent.
			aRow addMorphBack: AlignmentMorph newVariableTransparentSpacer.
			aRow addMorphBack: (stat _ (inst _ scriptedPlayer scriptInstantiationForSelector: cmd) statusControlMorph).
			inst updateStatusMorph: stat]].

	aRow beSticky; disableDragNDrop.

	^ aRow