tileForArgType: typeSymbol inViewer: aViewer

	| aColor aPlayer |
	typeSymbol == #player ifTrue:
		[aPlayer _ self presenter
			ifNotNil:
				[self presenter standardPlayer]
			ifNil:  "It happens, if costume is not currently in a world"
				[self].
		^ aViewer tileForPlayer:  aPlayer].
	aColor _ ScriptingSystem colorForType: typeSymbol.
	typeSymbol == #number ifTrue: [^ 5 newTileMorphRepresentative typeColor: aColor].
	typeSymbol == #string ifTrue: [^ 'abc' newTileMorphRepresentative typeColor: aColor].
	typeSymbol == #boolean ifTrue: [^ true newTileMorphRepresentative typeColor: aColor].
	typeSymbol == #sound ifTrue: [^ SoundTile new typeColor: aColor].
	typeSymbol == #menu ifTrue: [^ MenuTile new typeColor: aColor].
	typeSymbol == #object ifTrue: [^ nil newTileMorphRepresentative typeColor: aColor].
	typeSymbol == #color ifTrue: [^ Color blue newTileMorphRepresentative].
	self error: 'Unrecognized type'