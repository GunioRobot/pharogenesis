elevateSleeve: nSteps
	| lastEdge nextEdge faces lastEdgeVertex nextEdgeVertex vtxList1 vtxList2 |
	self isSleeve ifFalse:[^#()].
	faces _ WriteStream on: #().
	e1 isBorderEdge ifTrue:[lastEdge _ e2. nextEdge _ e3].
	e2 isBorderEdge ifTrue:[lastEdge _ e3. nextEdge _ e1].
	e3 isBorderEdge ifTrue:[lastEdge _ e1. nextEdge _ e2].
	lastEdgeVertex _ lastEdge center @ lastEdge elevationHeight.
	nextEdgeVertex _ nextEdge center @ nextEdge elevationHeight.
	"Elevate fan vertices, if any"
	lastEdge fanVertices ifNotNil:[
		faces nextPutAll: (self elevateFan: lastEdge fanVertices to: lastEdgeVertex steps: nSteps)].
	nextEdge fanVertices ifNotNil:[
		faces nextPutAll: (self elevateFan: nextEdge fanVertices to: nextEdgeVertex steps: nSteps)].
	"Connect edges"
	vtxList1 _ self elevateFrom: lastEdge origin @ 0 to: lastEdgeVertex steps: nSteps.
	vtxList2 _ self elevateFrom: nextEdge destination @ 0to: nextEdgeVertex steps: nSteps.
	self elevateConnect: vtxList1 with: vtxList2 into: faces.
	vtxList1 _ self elevateFrom: nextEdge origin @ 0 to: nextEdgeVertex steps: nSteps.
	vtxList2 _ self elevateFrom: lastEdge destination @ 0 to: lastEdgeVertex steps: nSteps.
	self elevateConnect: vtxList1 with: vtxList2 into: faces.
	^faces contents