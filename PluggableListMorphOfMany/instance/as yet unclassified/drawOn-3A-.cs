drawOn: aCanvas
	| onMorph |
	super drawOn: aCanvas.
	1 to: list size do:  "NOTE: should be optimized to only visible morphs"
		[:index |
		(model listSelectionAt: index) ifTrue:
			[onMorph _ scroller submorphs at: index.
			aCanvas fillRectangle:
				(((scroller transformFrom: self) localBoundsToGlobal: onMorph bounds)
						intersect: scroller bounds)
				color: color darker]]