paintingBoundsAround: aPoint
	"Return a rectangle for painting centered on the given point. Both the argument point and the result rectangle are in world coordinates."

	| paintExtent maxPaintArea myBnds |
	paintExtent _ self reasonablePaintingExtent.
	maxPaintArea _ paintExtent x * paintExtent y.
	myBnds _ self boundsInWorld.
	(myBnds area <= maxPaintArea) ifTrue: [^ myBnds].
	^ (aPoint - (paintExtent // 2) extent: paintExtent) intersect: myBnds
