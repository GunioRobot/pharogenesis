markExteriorEdges: thisWay in: pointList
	"Mark edges as exteriors"
	| lastPt nextPt lastEdge nextEdge |
	lastPt _ pointList last.
	lastEdge _ self locatePoint: lastPt.
	lastEdge origin = lastPt 
		ifFalse:[lastEdge _ lastEdge symmetric].
	nextEdge _ self findEdgeFrom: lastPt to: (pointList atWrap: pointList size-1) lastEdge: lastEdge.
	lastEdge := nextEdge.
	1 to: pointList size do:[:i|
		nextPt _ pointList at: i.
		lastPt = nextPt ifFalse:[
			nextEdge _ self findEdgeFrom: lastPt to: nextPt lastEdge: lastEdge.
			nextEdge ifNil:[
				nextEdge _ self locatePoint: nextPt.
				lastEdge destination = nextPt 
					ifFalse:[lastEdge _ lastEdge symmetric].
			] ifNotNil:[
				self flagExteriorEdgesFrom: lastEdge to: nextEdge direction: thisWay.
			].
			lastEdge _ nextEdge symmetric].
		lastPt _ nextPt.
	].
