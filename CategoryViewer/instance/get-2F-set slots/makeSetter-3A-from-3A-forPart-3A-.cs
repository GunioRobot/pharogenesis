makeSetter: evt from: aMorph forPart: args

	| argType m argTile selfTile argValue |
	argType _ args last.
	m _ PhraseTileMorph new setAssignmentRoot: args first asSymbol
		type: #command
		rcvrType: #player
		argType: argType.

	argValue _ self scriptedPlayer perform: (ScriptingSystem getterSelectorFor: args first asSymbol).
	(argValue isKindOf: Player)
		ifTrue:
			[argTile _ argValue tileReferringToSelf]
		ifFalse:
			[argTile _ scriptedPlayer tileForArgType: argType inViewer: self.
			argTile setLiteral: argValue; updateLiteralLabel.].
	argTile position: m lastSubmorph position.

	m lastSubmorph addMorph: argTile.

	selfTile _ self tileForSelf bePossessive.
	selfTile position: m firstSubmorph position.
	m firstSubmorph addMorph: selfTile.

	m enforceTileColorPolicy.
	owner ifNotNil: [self primaryHand attachMorph: m]
		ifNil: [^ m].
