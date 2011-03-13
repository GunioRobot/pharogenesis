basicBox
	| aBox minSide anExtent w |
	minSide _ 4 * self handleSize.
	anExtent _ ((self width + self handleSize + 8) max: minSide) @
				((self height + self handleSize + 8) max: minSide).
	aBox _ Rectangle center: self center extent: anExtent.
	w _ self world ifNil:[target outermostWorldMorph].
	^ w
		ifNil:
			[aBox]
		ifNotNil:
			[aBox intersect: (w viewBox insetBy: 8@8)]
