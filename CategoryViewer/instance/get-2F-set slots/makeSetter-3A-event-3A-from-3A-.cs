makeSetter: selectorAndTypePair event: evt from: aMorph 
	"Classic tiles: make a Phrase that comprises a setter of a slot, and hand it to the user."

	| argType m argTile selfTile argValue actualGetter |
	argType := selectorAndTypePair second.
	actualGetter := selectorAndTypePair first asSymbol.
	m := PhraseTileMorph new 
				setAssignmentRoot: (Utilities inherentSelectorForGetter: actualGetter)
				type: #command
				rcvrType: #Player
				argType: argType
				vocabulary: self currentVocabulary.
	argValue := self scriptedPlayer 
				perform: selectorAndTypePair first asSymbol.
	(argValue isPlayerLike) 
		ifTrue: [argTile := argValue tileReferringToSelf]
		ifFalse: 
			[argTile := ScriptingSystem tileForArgType: argType.
			(argType == #Number and: [argValue isNumber]) 
				ifTrue: 
					[(scriptedPlayer decimalPlacesForGetter: actualGetter) 
						ifNotNilDo: [:places | (argTile findA: UpdatingStringMorph) decimalPlaces: places]].
			argTile
				setLiteral: argValue;
				updateLiteralLabel].
	argTile position: m lastSubmorph position.
	m lastSubmorph addMorph: argTile.
	selfTile := self tileForSelf bePossessive.
	selfTile position: m firstSubmorph position.
	m firstSubmorph addMorph: selfTile.
	m enforceTileColorPolicy.
	m openInHand