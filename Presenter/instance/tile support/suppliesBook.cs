suppliesBook
	"Return a book with pages containing bins of parts.  Everything in the supplies book is for drag-n-drop"

	| book aColor |
	aColor _ Color blue veryMuchLighter.
	book _ BookMorph new borderWidth: 2.
	book  removeEverything; addKidsDressing.

	book
		insertPageLabel: 'Values'
		morphs: (Array with: (self partsBinFor: self valueTiles color: aColor)).
	book
		insertPageLabel: 'Comparing and Testing'
		morphs: (Array with: (self partsBinFor: self booleanTiles color: aColor)).
	book
		insertPageLabel: 'Arithmetic'
		morphs: (Array with: (self partsBinFor: self arithmeticTiles color: aColor)).

	book goToPage: 1.
	book openToDragNDrop: false.
	^ book