markExteriorEdges: timeStamp
	| nextEdge |
	quadEdge timeStamp = timeStamp ifTrue:[^self].
	quadEdge timeStamp: timeStamp.
	self isExteriorEdge: true.
	nextEdge _ self.
	[nextEdge _ nextEdge originNext.
	nextEdge == self or:[nextEdge isBorderEdge]] whileFalse:[
		nextEdge symmetric markExteriorEdges: timeStamp.
	].
	nextEdge _ self.
	[nextEdge _ nextEdge originPrev.
	nextEdge == self or:[nextEdge isBorderEdge]] whileFalse:[
		nextEdge symmetric markExteriorEdges: timeStamp.
	].