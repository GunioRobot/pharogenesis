drawOn: aCanvas
	super drawOn: aCanvas.
	selectedMorph ifNotNil:
		[aCanvas fillRectangle:
			(((scroller transformFrom: self) invertBoundsRect: selectedMorph bounds)
						intersect: scroller bounds)
				color: color darker]