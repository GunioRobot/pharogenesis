processPolygon: vb
	"Process a polygon from the vertex buffer that requires partial clipping"
	| outMask vtxArray tempVtxArray count |
	outMask := vb clipFlags bitAnd: OutAllMask.
	vtxArray _ vb vertexArray.
	tempVtxArray _ vtxArray clone.
	"Note: tempVtxArray has the SAME contents as vtxArray since the data is stored inplace.
	Thus we can decide from which buffer to start the clipping operation later on."
	count _ self clipPolygon: vtxArray count: vb vertexCount with: tempVtxArray mask: outMask.
	vb vertexCount: count.
	count < 3 ifTrue:[^false].
	^nil