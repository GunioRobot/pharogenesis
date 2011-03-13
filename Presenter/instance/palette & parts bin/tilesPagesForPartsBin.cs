tilesPagesForPartsBin
	| aPage bools aTile aPhrase |
	aPage _ self newPageForStandardPartsBin padding: 30.
	bools _ self booleanTiles.
	aPage addMorphBack: bools first markAsPartsDonor.
	aPage addMorphBack: bools last markAsPartsDonor.
	aPage addMorphBack: self arithmeticTiles first markAsPartsDonor.
	aPage addMorphBack: RandomNumberTile new markAsPartsDonor.

	#(('(Sensor anyButtonPressed)' 'button down?')
	('(Sensor noButtonPressed)' 'button up?')
	"('(Sensor keyboardPressed)' 'key hit?')   sucker doesn't work for some reason") do:
		[:pair |
			aPhrase _ SystemQueryPhrase new.
			aTile _ BooleanTile new.
			aTile setExpression: pair first label: pair second.
			aPhrase addMorph: aTile.
			aPage addMorphBack: aPhrase].

	aPage enforceTileColorPolicy.
	aPage replaceTallSubmorphsByThumbnails.
	^ OrderedCollection with: aPage  "room to grow"