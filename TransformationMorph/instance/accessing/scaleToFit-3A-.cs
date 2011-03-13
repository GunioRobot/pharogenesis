scaleToFit: anExtent

	| scalePoint scaleFactor |
	scalePoint _ anExtent / submorphs first fullBounds extent.
	scaleFactor _ (scalePoint x abs min: scalePoint y abs) asFloat.
	((scaleFactor - 1.0) abs < 0.05) ifTrue: [scaleFactor _ 1.0].
	self scale: ((scaleFactor min: 8.0) max: 0.05).
