newDrawingFromMenu
	self world assureNotPaintingElse: [^ self].
	self attachMorph: PaintInvokingMorph new markAsPartsDonor