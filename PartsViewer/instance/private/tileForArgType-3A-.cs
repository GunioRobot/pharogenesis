tileForArgType: typeSymbol

	| aColor |
	aColor _ TilePadMorph colorForType: typeSymbol.
	typeSymbol == #player ifTrue:
		[^ self tileForPlayer:  self presenter standardPlayer].

	#(number string) with:
	#(5  'chars')  do:
		[:sym :lit | typeSymbol == sym ifTrue: [^ lit newTileMorphRepresentative typeColor: aColor]].

	typeSymbol == #boolean ifTrue:
		[^ true newTileMorphRepresentative].

	typeSymbol == #sound ifTrue:
		[^ SoundTile new typeColor: aColor].

	typeSymbol == #object ifTrue:
		[^ nil newTileMorphRepresentative typeColor: aColor].

	typeSymbol == #color ifTrue:
		[^ Color blue newTileMorphRepresentative].

	typeSymbol == #boolean ifTrue:
		[^ true newTileMorphRepresentative typeColor: aColor].

	self halt: 'Unrecognized type'