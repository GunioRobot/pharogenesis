defaultArgumentTile
	"Answer a tile to represent the type"

	| aTile  |
	aTile _ ScriptNameTile new dataType: self vocabularyName.
	aTile addArrows.
	aTile setLiteral: #emptyScript.
	^ aTile