deleteBackgroundPainting
	backgroundMorph
		ifNotNil:
			[backgroundMorph delete.
			backgroundMorph := nil]
		ifNil:
			[self inform: 'There is presently no
background painting
to delete.']