tileForArgType: typeSymbol inViewer: aViewer
	"Answer a tile to represent a value of the given type in the given viewer"

	| aColor aPlayer |
	typeSymbol == #player ifTrue:
		[aPlayer _ self presenter
			ifNotNil:
				[self presenter standardPlayer]
			ifNil:  "It happens, if costume is not currently in a world"
				[self].
		^ (CategoryViewer new) tileForPlayer:  aPlayer].
	aColor _ ScriptingSystem colorForType: typeSymbol.

	typeSymbol == #point ifTrue: [^ TileMorph new setLiteral: 0@0; typeColor: aColor].
	typeSymbol == #number ifTrue: [^ 5 newTileMorphRepresentative typeColor: aColor].
	typeSymbol == #string ifTrue: [^ 'abc' newTileMorphRepresentative typeColor: aColor].
	typeSymbol == #boolean ifTrue: [^ true newTileMorphRepresentative typeColor: aColor].
	typeSymbol == #sound ifTrue: [^ SoundTile new typeColor: aColor].
	typeSymbol == #menu ifTrue: [^ MenuTile new typeColor: aColor].
	typeSymbol == #object ifTrue: [^ nil newTileMorphRepresentative typeColor: aColor].
	typeSymbol == #color ifTrue: [^ Color blue newTileMorphRepresentative].
	typeSymbol == #buttonPhase ifTrue: [^ SymbolListTile new choices: #(buttonDown whilePressed buttonUp) dataType:  typeSymbol].
	typeSymbol == #text ifTrue: [^ ("(TextMorph new contents: 'setup')" 'aborning' newTileMorphRepresentative) typeColor:  aColor].

	self error: 'Unrecognized type'