scaleToMatch: aPoint
	| scaleFactor tfm originalScale |
	tfm _ transform withScale: 1.0.
	originalScale _ ((tfm localBoundsToGlobal: self renderedMorph fullBounds) corner -
		(tfm localPointToGlobal: self renderedMorph referencePosition)) r.
	"Catch cases where the reference point is on fullBounds corner"
	originalScale < 1.0 ifTrue:[originalScale _ 1.0].
	scaleFactor _ (aPoint - self referencePosition) r / originalScale.
	scaleFactor _ scaleFactor < 1.0
		ifTrue: [scaleFactor detentBy: 0.05 atMultiplesOf: 0.25 snap: false]
		ifFalse: [scaleFactor detentBy: 0.1 atMultiplesOf: 0.5 snap: false].
	self adjustAfter:[self scale: ((scaleFactor min: 8.0) max: 0.1)].