forBook: aBookMorph

	book _ aBookMorph.
	pageHolder removeAllMorphs.
	pageHolder addAllMorphs:
		(book pages collect: [:p | BookPageThumbnailMorph new page: p]).
	pageHolder extent: pageHolder width@pageHolder fullBounds height.
