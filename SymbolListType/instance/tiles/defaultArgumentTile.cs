defaultArgumentTile
	"Answer a tile to represent the type"

	| aTile choices |
	aTile _ SymbolListTile new choices: (choices _ self choices) dataType: self vocabularyName.
	aTile addArrows.
	aTile setLiteral: choices first.
	^ aTile