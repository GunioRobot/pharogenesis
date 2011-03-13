replaceBook: aName with: newBook
	"replace the old book with a new book.  Great for bringing Alan's scaffolding in"
"Inspect the new bookMorph.  In it, set 
	AA _ self.
Inspect the TabbedPaletteComplex.  Execute:
	self replaceBook: 'Toy' with: AA.
"
 
	newBook setProperty: #name toValue: 'Toy'.
	self selectTabNamed: aName.
	currentPage delete.
	self addMorph: newBook.
	pages add: newBook after: currentPage.
	pages remove: currentPage.
	newBook position: currentPage position.
	currentPage _ newBook.
	self changed.