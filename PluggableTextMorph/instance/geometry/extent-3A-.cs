extent: newExtent

	bounds extent = newExtent ifTrue: [^ self].
	super extent: (newExtent max: 36@16).
	textMorph ifNotNil:
		[textMorph extent: (self innerBounds width-6)@self height].
	self setScrollDeltas
