makeNewDrawingWithin

	| bnds |
	bnds _ self paintingBoundsAround: self boundsInWorld center.
	self primaryHand makeNewDrawingInBounds: bnds pasteUpMorph: self.
