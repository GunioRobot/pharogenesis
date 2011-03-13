suppliesBook
	"Return a book with pages containing bins of parts.  Everything in the supplies book is for drag-n-drop"

	| book |
	book _ BookMorph newSticky borderWidth: 2; setNameTo: 'Misc'.
	book  removeEverything; addKidsDressing.

	book insertPageLabel: 'Shapes'
		morphs: (Array with: (self partsDonorBinFor: self authoringWidgets)).
	
	book insertPageLabel: 'Widgets'
		morphs: (Array with: (self partsDonorBinFor: self alternateWidgets)).

	book insertPageLabel: 'Holder, Joystick, Book'
		morphs: (Array with: (self partsDonorBinFor: self page3Widgets)).

	book
		insertPageLabel: 'Values'
		morphs: (Array with: (self partsBinFor: self presenter valueTiles)).
	book
		insertPageLabel: 'Comparing and Testing'
		morphs: (Array with: (self partsBinFor: self presenter booleanTiles)).
	book
		insertPageLabel: 'Arithmetic'
		morphs: (Array with: (self partsBinFor: self presenter arithmeticTiles)).

	book goToPage: 1.
	book openToDragNDrop: false.
	book beThoroughlyRepelling.
	^ book