edgeFrom: start to: end 
	| startVertex endVertex halfedge twinedge oldedge |
	start asPoint = end asPoint ifTrue: [self error: 'start = end'].
	startVertex _ self vertexAt: start.
	endVertex _ self vertexAt: end.
	halfedge _ POHalfedge new origin: startVertex.
	twinedge _ POHalfedge new origin: endVertex.
	halfedge opposite: twinedge;
	 next: twinedge;
	 prev: twinedge.
	twinedge opposite: halfedge;
	 next: halfedge;
	 prev: halfedge.
	oldedge _ self halfedges at: halfedge ifAbsent:
			[startVertex halfedge ifNil: [startVertex halfedge: halfedge]
				ifNotNil: [self attachHalfedge: halfedge].
			endVertex halfedge ifNil: [endVertex halfedge: twinedge]
				ifNotNil: [self attachHalfedge: twinedge].
			self halfedges at: twinedge put: twinedge.
			self halfedges at: halfedge put: halfedge.].
	^ oldedge