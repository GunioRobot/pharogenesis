makeSetter: evt from: aMorph forPart: args

	| argType m argTile selfTile |
	argType _ args last.
	m _ PhraseTileMorph new setAssignmentRoot: args first asSymbol
		type: #command
		rcvrType: #player
		argType: argType.

	argTile _ self tileForArgType: argType.
	argTile position: m lastSubmorph position.
	m lastSubmorph addMorph: argTile.

	selfTile _ self tileForSelf bePossessive.
	selfTile position: m firstSubmorph position.
	m firstSubmorph addMorph: selfTile.

	self presenter coloredTilesEnabled ifFalse:
		[m makeAllTilesGreen].

	self primaryHand attachMorph: m.
