insertEdgeFrom: lastPt to: nextPt lastEdge: prevEdge into: outPoints
	| midPt lastEdge nextEdge dst |
	dst _ lastPt - nextPt.
	(dst dotProduct: dst) < outlineThreshold ifTrue:[^nil].
	midPt _ lastPt interpolateTo: nextPt at: 0.5.
	self insertPoint: midPt.
	lastEdge _ prevEdge.
	nextEdge _ self assureEdgeFrom: lastPt to: midPt lastEdge: lastEdge into: outPoints.
	outPoints nextPut: midPt.
	nextEdge ifNil:[^nil].
	lastEdge _ nextEdge symmetric originNext.
	nextEdge _ self assureEdgeFrom: midPt to: nextPt lastEdge: lastEdge into: outPoints.
	^nextEdge