oppositeEdgeOf: aVertex 
	^ (self edges
		detect: [:edge | (edge oneEndIs: aVertex) not]).