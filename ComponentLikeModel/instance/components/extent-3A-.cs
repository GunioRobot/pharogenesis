extent: newExtent
	super extent: newExtent.
	self submorphsDo: [:m | (m isKindOf: PinMorph) ifTrue: [m placeFromSpec]]