book: aBook
	book _ aBook.
	self addMorph: aBook frame: (0@0 extent: 1@1).
	book beSticky.
	book hResizing: #none; vResizing: #none.
	nextButton target: aBook.
	prevButton target: aBook