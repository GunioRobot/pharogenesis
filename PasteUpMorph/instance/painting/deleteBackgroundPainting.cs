deleteBackgroundPainting
	backgroundMorph
		ifNotNil:
			[backgroundMorph delete.
			backgroundMorph _ nil]
		ifNil:
			[self inform: 'There is presently no
background painting
to delete.']