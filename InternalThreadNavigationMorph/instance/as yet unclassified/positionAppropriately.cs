positionAppropriately

	| others otherRects overlaps |
	others _ self world submorphs select: [ :each | each ~~ self and: [each isKindOf: self class]].
	otherRects _ others collect: [ :each | each bounds].
	self align: self fullBounds bottomRight with: self world bottomRight.

	[
		overlaps _ false.
		otherRects do: [ :r |
			(r intersects: bounds) ifTrue: [overlaps _ true. self bottom: r top].
		].
		self top < self world top ifTrue: [
			self bottom: self world bottom.
			self right: self left - 1.
		].
		overlaps
	] whileTrue.