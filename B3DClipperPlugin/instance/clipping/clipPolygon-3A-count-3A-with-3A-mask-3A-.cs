clipPolygon: vtxArray count: vtxCount with: tempVtxArray mask: outMask
	| count |
	self var: #vtxArray declareC:'int *vtxArray'.
	self var: #tempVtxArray declareC:'int *tempVtxArray'.
	"Check if the polygon is outside one boundary only.
	If so, just do this single clipping operation avoiding multiple enumeration."
	outMask = OutLeftBit 
		ifTrue:[^self clipPolygonLeftFrom: tempVtxArray to: vtxArray count: vtxCount].
	outMask = OutRightBit 
		ifTrue:[^self clipPolygonRightFrom: tempVtxArray to: vtxArray count: vtxCount].
	outMask = OutTopBit 
		ifTrue:[^self clipPolygonTopFrom: tempVtxArray to: vtxArray count: vtxCount].
	outMask = OutBottomBit 
		ifTrue:[^self clipPolygonBottomFrom: tempVtxArray to: vtxArray count: vtxCount].
	outMask = OutFrontBit 
		ifTrue:[^self clipPolygonFrontFrom: tempVtxArray to: vtxArray count: vtxCount].
	outMask = OutBackBit 
		ifTrue:[^self clipPolygonBackFrom: tempVtxArray to: vtxArray count: vtxCount].
	"Just do each of the clipping operations"
	count _ vtxCount.
	count _ self clipPolygonLeftFrom: vtxArray to: tempVtxArray count: count.
	count = 0 ifTrue:[^0].
	count _ self clipPolygonRightFrom: tempVtxArray to: vtxArray count: count.
	count = 0 ifTrue:[^0].
	count _ self clipPolygonTopFrom: vtxArray to: tempVtxArray count: count.
	count = 0 ifTrue:[^0].
	count _ self clipPolygonBottomFrom: tempVtxArray to: vtxArray count: count.
	count = 0 ifTrue:[^0].
	count _ self clipPolygonFrontFrom: vtxArray to: tempVtxArray count: count.
	count = 0 ifTrue:[^0].
	count _ self clipPolygonBackFrom: tempVtxArray to: vtxArray count: count.
	^count