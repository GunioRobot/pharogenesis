restoreMorphicDisplay

	DisplayScreen startUp.
	(self getOuterMorphicWorld ifNil: [^ self])
		extent: self extent;
		viewBox: self boundingBox;
		handsDo: [:h | h visible: true; showTemporaryCursor: nil];
		restoreFlapsDisplay;
		fullRepaintNeeded.
	WorldState addDeferredUIMessage: [
		Cursor normal show.
	].
