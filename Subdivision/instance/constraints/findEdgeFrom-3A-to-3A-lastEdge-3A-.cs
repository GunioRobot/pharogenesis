findEdgeFrom: lastPt to: nextPt lastEdge: lastEdge
	"Find and return the edge connecting nextPt and lastPt.
	lastEdge starts at lastPt so we can simply run around all
	the edges at lastPt and find one that ends in nextPt."
	| nextEdge destPt |
	nextEdge _ lastEdge.
	[destPt _ nextEdge destination.
	destPt x = nextPt x and:[destPt y = nextPt y]] whileFalse:[
		nextEdge _ nextEdge originNext.
		nextEdge = lastEdge ifTrue:[^nil].
	].
	^nextEdge