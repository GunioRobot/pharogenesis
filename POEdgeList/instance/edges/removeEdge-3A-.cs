removeEdge: anEdge 
	anEdge origin isDeadEnd
		ifTrue: [self vertices removeKey: (anEdge origin halfedge: nil) asPoint
				ifAbsent: []]
		ifFalse: [self cutHalfedge: anEdge].
	anEdge opposite origin isDeadEnd
		ifTrue: [self vertices removeKey: (anEdge destination halfedge: nil) asPoint
				ifAbsent: []]
		ifFalse: [self cutHalfedge: anEdge opposite].
	self halfedges removeKey: anEdge ifAbsent: [].
	self halfedges removeKey: anEdge opposite ifAbsent: [].