basicBox
	| aBox minSide anExtent |
	minSide _ 4 * self handleSize.
	anExtent _ ((self width + self handleSize + 8) max: minSide) @
				((self height + self handleSize + 8) max: minSide).
	aBox _ Rectangle center: self center extent: anExtent.
	^ self world
		ifNil:
			[aBox]
		ifNotNil:
			[aBox intersect: (self world viewBox insetBy: 8@8)]
