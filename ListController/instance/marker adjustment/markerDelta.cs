markerDelta

	| viewList |
	viewList := view list.
	viewList compositionRectangle height == 0 ifTrue: [
		^ (marker top - scrollBar inside top) - scrollBar inside height
	].
	^ (marker top - scrollBar inside top) -
		((viewList clippingRectangle top -
				viewList compositionRectangle top) asFloat /
			viewList compositionRectangle height asFloat *
			scrollBar inside height asFloat) rounded
