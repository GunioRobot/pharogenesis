elevateJunctionEdge: anEdge height: height steps: nSteps
	"Elevate the given edge of a junction"
	| faceVertex faces edgeVertex vtxList1 vtxList2 |
	faceVertex _ self center @ height.
	anEdge fanVertices ifNotNil:[
		"Connect the fan vertices with self center"
		^self elevateFan: anEdge fanVertices to: faceVertex steps: nSteps].
	"Connect 
		(anEdge origin, anEdge center, self center)
		(self center, anEdge center, anEdge destination)"
	faces _ WriteStream on: #().
	edgeVertex _ anEdge center @ anEdge elevationHeight.
	vtxList1 _ self elevateFrom: anEdge origin @ 0 to: edgeVertex steps: nSteps.
	vtxList2 _ self elevateFrom: anEdge origin @ 0 to: faceVertex steps: nSteps.
	self elevateConnect: vtxList1 with: vtxList2 into: faces.
	vtxList1 _ self elevateFrom: anEdge destination @ 0 to: faceVertex steps: nSteps.
	vtxList2 _ self elevateFrom: anEdge destination @ 0 to: edgeVertex steps: nSteps.
	self elevateConnect: vtxList1 with: vtxList2 into: faces.
	^faces contents