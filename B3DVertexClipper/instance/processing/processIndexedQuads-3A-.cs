processIndexedQuads: vb
	"Clip an indexed quad set"
	| vtxArray idxArray tempVB idx1 idx2 idx3 maxVtx maxIdx index lastIndex clipFlags vtx returnValue |
	self flag: #b3dPrimitive.
	returnValue _ false. "Assume we don't see nothing"
	tempVB _ B3DVertexBuffer new.
	vtxArray _ vb vertexArray.
	idxArray _ vb indexArray.
	maxVtx _ vb indexCount.
	maxIdx _ vb indexCount.
	lastIndex _ -3. "Hack the lastIndex ;-)"
	[index _ self primNextClippedQuadAfter: lastIndex + 4
					vertices: vtxArray count: maxVtx
					indexes: idxArray count: maxIdx.
	index = 0] whileFalse:[
		"Need a partial clip here, storing the triangulated polygon at the end"
		tempVB reset.
		clipFlags _ InAllMask + OutAllMask.
		"Copy the poly into tempVB"
		0 to: 3 do:[:i|
			vtx _ vtxArray at: (idxArray at: index+i).
			idxArray at: index+i put: 0.
			tempVB addClipVertex: vtx.
			clipFlags _ clipFlags bitAnd: vtx clipFlags].
		tempVB clipFlags: clipFlags.
		self processPolygon: tempVB.
		tempVB vertexCount > 2 ifTrue:[
			returnValue _ nil. "We see some parts and not others"
			idx1 _ vb addClipVertex: (tempVB vertexArray at: 1).
			3 to: tempVB vertexCount do:[:j|
				idx2 _ vb addClipVertex: (tempVB vertexArray at: j-1).
				idx3 _ vb addClipVertex: (tempVB vertexArray at: j).
				vb addClipIndex: idx1.
				vb addClipIndex: idx2.
				vb addClipIndex: idx3.
				vb addClipIndex: idx3.
			].
		].
		lastIndex _ index.
	].
	^returnValue