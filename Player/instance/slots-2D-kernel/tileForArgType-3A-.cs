tileForArgType: typeSymbol

	| aColor |
	typeSymbol == #player ifTrue:
		[^ self tileForPlayer:  self presenter standardPlayer].
	aColor _ ScriptingSystem colorForType: typeSymbol.
	typeSymbol == #number ifTrue: [^ 5 newTileMorphRepresentative typeColor: aColor].
	typeSymbol == #string ifTrue: [^ 'abc' newTileMorphRepresentative typeColor: aColor].
	typeSymbol == #boolean ifTrue: [^ true newTileMorphRepresentative typeColor: aColor].
	typeSymbol == #sound ifTrue: [^ SoundTile new typeColor: aColor].
	typeSymbol == #menu ifTrue: [^ MenuTile new typeColor: aColor].
	typeSymbol == #object ifTrue: [^ nil newTileMorphRepresentative typeColor: aColor].
	typeSymbol == #color ifTrue: [^ Color blue newTileMorphRepresentative].
	self error: 'Unrecognized type'