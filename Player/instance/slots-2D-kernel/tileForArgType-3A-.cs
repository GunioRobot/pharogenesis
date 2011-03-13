tileForArgType: typeSymbol
	"Anwer a default tile to represent a datum of the given argument type"

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
	typeSymbol == #buttonPhase ifTrue: [^ SymbolListTile new choices: #(buttonDown whilePressed buttonUp) dataType: typeSymbol].

	self error: 'Unrecognized type'