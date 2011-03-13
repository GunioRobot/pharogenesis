mmarkerDelta

	| viewList |
	viewList _ view list.
	viewList compositionRectangle height == 0 ifTrue: [
		^ (marker top - self mscrollGrayRect top) - (self mscrollGrayRect height - marker height)
	].
	^ (marker top - self mscrollGrayRect top) -
		((viewList clippingRectangle top -
				viewList compositionRectangle top) asFloat /
			(viewList compositionRectangle height - viewList clippingRectangle height) asFloat *
			(self mscrollGrayRect height - marker height) asFloat) rounded
