tileForArgType: typeSymbol inViewer: aViewer
	"Answer a tile to represent an argument of the given type; the viewer argument is actually used, but nowadays in only a vacuous sense that should be excised, since the viewer does not use anything about itself in its subsequent code"

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
	typeSymbol == #buttonPhase ifTrue: [^ SymbolListTile new choices: #(buttonDown whilePressed buttonUp) dataType:  typeSymbol].

	self error: 'Unrecognized type'