makeGetter: evt from: aMorph forPart: args

	| m selfTile selector aType firstArg |
	(aType _ args last) == #unknown ifTrue: [^ self beep].

	(#(colorSees isOverColor touchesA) includes: (firstArg _ args first))
		ifFalse:
			[m _ PhraseTileMorph new setSlotRefOperator: args first asSymbol type: aType]
		ifTrue:
			[(firstArg == #colorSees) ifTrue: [m _ self colorSeesPhrase].
			(firstArg == #isOverColor) ifTrue: [m _ self seesColorPhrase].
			(firstArg == #touchesA) ifTrue: [m _ self touchesAPhrase].
		].

	selfTile _ self tileForSelf bePossessive.
	selfTile position: m firstSubmorph position.
	m firstSubmorph addMorph: selfTile.

	selector _ m submorphs at: 2.
	(aType == #number) ifTrue:
		[selector addSuffixArrow].
	selector updateLiteralLabel.

	m enforceTileColorPolicy.

	owner ifNotNil: [self primaryHand attachMorph: m]
		ifNil: [^ m].
