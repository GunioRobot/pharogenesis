computeThumbnail
	"Make a thumbnail from my morph."

	(contentsMorph isKindOf: PasteUpMorph) 
		ifTrue: [thumbnail _ contentsMorph smallThumbnailForPageSorter]
		ifFalse: [self updateThumbnail]