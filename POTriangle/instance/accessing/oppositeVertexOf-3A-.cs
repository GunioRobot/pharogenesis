oppositeVertexOf: anEdge 
	^ self vertices detect: [:vertex| (anEdge oneEndIs: vertex) not]