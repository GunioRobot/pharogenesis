scaleToFit: anExtent
	| scaleFactor |
	scaleFactor _ self scale * (anExtent r / self fullBounds extent r).
	scaleFactor _ scaleFactor < 1.0
		ifTrue: [scaleFactor detentBy: 0.05 atMultiplesOf: 0.25 snap: false]
		ifFalse: [scaleFactor detentBy: 0.1 atMultiplesOf: 0.5 snap: false].
	self scale: ((scaleFactor min: 8.0) max: 0.1).
	self extent: anExtent