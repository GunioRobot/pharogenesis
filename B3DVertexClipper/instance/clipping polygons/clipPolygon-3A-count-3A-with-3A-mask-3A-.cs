clipPolygon: vtxArray count: vtxCount with: tempVtxArray mask: outMask
	"Clip the polygon defined by vtxCount vertices in vtxArray. tempVtxArray is a temporary storage area used for copying the vertices back and forth during clipping operation. outMask is the full clip mask of the vertex buffer, allowing some optimizations of the clipping code.
	NOTE: It is significant here that the contents of vtxArray and tempVtxArray are equal."
	| count |
	self flag: #b3dPrimitive.
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