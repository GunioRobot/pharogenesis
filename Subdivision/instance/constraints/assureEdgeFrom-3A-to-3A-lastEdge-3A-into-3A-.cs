assureEdgeFrom: lastPt to: nextPt lastEdge: lastEdge into: outPoints
	"Find and return the edge connecting nextPt and lastPt.
	lastEdge starts at lastPt so we can simply run around all
	the edges at lastPt and find one that ends in nextPt.
	If none is found, subdivide between lastPt and nextPt."
	| nextEdge destPt |
	nextEdge _ lastEdge.
	[destPt _ nextEdge destination.
	destPt x = nextPt x and:[destPt y = nextPt y]] whileFalse:[
		nextEdge _ nextEdge originNext.
		nextEdge = lastEdge ifTrue:[
			"Edge not found. Subdivide and start over"
			nextEdge _ self insertEdgeFrom: lastPt to: nextPt lastEdge: lastEdge into: outPoints.
			nextEdge ifNil:[^nil].
		].
	].
	nextEdge isBorderEdge: true.
	^nextEdge
