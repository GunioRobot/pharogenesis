drawOn: aCanvas
	super drawOn: aCanvas.
	selectedMorph ifNotNil:
		[aCanvas fillRectangle:
			(((scroller transformFrom: self) localBoundsToGlobal: selectedMorph bounds)
						intersect: scroller bounds)
				color: color darker]