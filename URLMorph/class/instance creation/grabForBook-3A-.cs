grabForBook: bookMorph
	"Create a URLMorph for this book.  Put it into the hand."

	| um bookUrl pageUrl pg |
	bookUrl _ bookMorph valueOfProperty: #url.
	pageUrl _ bookMorph currentPage url.	"should have one!"
	pg _ SqueakPageCache atURL: pageUrl.
	(SqueakPage stemUrl: bookUrl) = (SqueakPage stemUrl: pageUrl) 
		ifTrue: [bookUrl _ true].		"not a shared book"
	um _ URLMorph newForURL: pageUrl.
	um setURL: pageUrl page: pg.
	pg isContentsInMemory ifTrue: [pg computeThumbnail].
	um isBookmark: true.
	um book: bookUrl.
	um removeAllMorphs.
	um color: Color transparent.
	Smalltalk currentHand attachMorph: um.
	^ um