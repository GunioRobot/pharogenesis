setClippingPlanesFrom: anObject
	"Set the clipping planes from the given object"
	| box center radius avgDist |
	box _ anObject boundingBox.
	center _ (box origin + box corner) * 0.5.
	radius _ (center - box origin) length.
	avgDist _ (position - center) length.
	self farDistance: avgDist + radius.
	avgDist > radius 
		ifTrue:[self nearDistance:
			((((center - position) normalized
				dot: (self direction normalized))
					* avgDist - radius) max: 1.0e-31)]
		ifFalse:[self nearDistance: (self farDistance * 0.00001)].