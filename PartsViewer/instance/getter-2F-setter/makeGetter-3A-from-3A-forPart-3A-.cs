makeGetter: evt from: aMorph forPart: args

	| m selfTile selector aType |
	(aType _ args last) == #unknown ifTrue: [^ self beep].

	args first == #colorSees 
		ifFalse: [m _ PhraseTileMorph new setSlotRefOperator: args first asSymbol
			type: aType]
		ifTrue: [m _ self colorSeesPhrase].

	selfTile _ self tileForSelf bePossessive.
	selfTile position: m firstSubmorph position.
	m firstSubmorph addMorph: selfTile.

	selector _ m submorphs at: 2.
	(aType == #number) ifTrue:
		[selector addSuffixArrow].
	selector updateLiteralLabel.

	self presenter coloredTilesEnabled ifFalse:
		[m makeAllTilesGreen].

	self primaryHand attachMorph: m.
