computeMarkerRegion 
	"Refer to the comment in ScrollController|computeMarkerRegion."

	paragraph compositionRectangle height = 0
		ifTrue:	[^0@0 extent: Preferences scrollBarWidth @ scrollBar inside height]
		ifFalse:	[^0@0 extent:
					Preferences scrollBarWidth 
						@ ((paragraph clippingRectangle height asFloat /
							self scrollRectangleHeight * scrollBar inside height) rounded
							min: scrollBar inside height)]