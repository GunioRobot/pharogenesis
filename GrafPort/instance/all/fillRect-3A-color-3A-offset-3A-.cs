fillRect: rect color: fillColor offset: aPoint

	fillColor class == InfiniteForm ifTrue: [
		self fillColor: nil.
		fillColor displayOnPort: ((self clippedBy: rect) colorMap: nil) at: aPoint.
		^ self].
	self copy: rect
		from: 0@0
		in: nil
		fillColor: fillColor
		rule: combinationRule.
