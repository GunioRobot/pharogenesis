book: aBook

	book _ aBook.
	self addMorph: aBook frame: (0@0 extent: 1@1).
	book beSticky.
	self extent: aBook extent + (0@self labelHeight).
	nextButton target: aBook.
	prevButton target: aBook