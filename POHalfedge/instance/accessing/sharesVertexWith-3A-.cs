sharesVertexWith: aHalfedge 
	(self origin = aHalfedge origin or: [self origin = aHalfedge destination])
		ifTrue: [^ self origin].
	(self destination = aHalfedge origin or: [self destination = aHalfedge destination])
		ifTrue: [^ self destination].
	^ nil