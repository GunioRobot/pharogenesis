restoreMorphicDisplay
	"Restore the morphic display -- initiated by explicit user request"

	DisplayScreen startUp.
	ThumbnailMorph recursionReset.
	self
		extent: Display extent;
		viewBox: Display boundingBox;
		handsDo: [:h | h visible: true; showTemporaryCursor: nil];
		restoreFlapsDisplay;
		fullRepaintNeeded.
	WorldState addDeferredUIMessage:
		[Cursor normal show]