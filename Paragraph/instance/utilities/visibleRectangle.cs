visibleRectangle 
	"May be less than the clippingRectangle if text ends part way down.
	Also some fearful history includes Display intersection;
	it shouldn't be necessary"

	^ (clippingRectangle intersect: compositionRectangle)
		intersect: destinationForm boundingBox