tilesForQuery: expressionString label: aLabel
	"Answer scripting tiles that represent the query,"

	| aPhrase aTile |
	aPhrase := SystemQueryPhrase new.
	aTile := BooleanTile new.
	aTile setExpression: expressionString  label: aLabel.
	aPhrase addMorph: aTile.
	^ aPhrase
