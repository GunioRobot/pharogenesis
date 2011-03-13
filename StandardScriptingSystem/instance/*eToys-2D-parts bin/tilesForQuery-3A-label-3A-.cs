tilesForQuery: expressionString label: aLabel
	"Answer scripting tiles that represent the query,"

	| aPhrase aTile |
	aPhrase _ SystemQueryPhrase new.
	aTile _ BooleanTile new.
	aTile setExpression: expressionString  label: aLabel.
	aPhrase addMorph: aTile.
	^ aPhrase
