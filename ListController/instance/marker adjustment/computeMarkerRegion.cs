computeMarkerRegion 
	"Refer to the comment in ScrollController|computeMarkerRegion."

	| viewList |
	viewList _ view list.
	viewList compositionRectangle height = 0
		ifTrue: [^ 0@0 extent: Preferences scrollBarWidth@scrollBar inside height].
	^ 0@0 extent: Preferences scrollBarWidth@
			((viewList clippingRectangle height asFloat /
						viewList compositionRectangle height *
							scrollBar inside height)
					rounded min: scrollBar inside height)