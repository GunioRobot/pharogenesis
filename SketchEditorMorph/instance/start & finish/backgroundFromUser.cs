backgroundFromUser

	^ self deliverPainting: (self getPaintingStartingWith: nil at: nil).
	"Caller will want to fetch (aSketchEditorMorph painting) to get one that has not been trimmed"