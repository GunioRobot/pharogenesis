systemQueryPhraseWithActionString: anActionString labelled: aLabel
	"Answer a SystemQueryPhrase with the given action string and label"

	| aTile aPhrase |
	
	aPhrase _ SystemQueryPhrase new.
	aTile _ BooleanTile new.
	aTile setExpression: anActionString label: aLabel.
	aPhrase addMorph: aTile.
	aPhrase enforceTileColorPolicy.
	^ aPhrase