processIndexed: vb
	| idxArray vtxArray index vtx zValue minIndex minZ wValue |
	idxArray _ vb indexArray.
	vtxArray _ vb vertexArray.
	minZ _ 10.0.
	minIndex _ 0.
	1 to: vb indexCount do:[:i|
		index _ idxArray at: i.
		index = 0 ifFalse:[
			vtx _ vtxArray at: index.
			zValue _ vtx rasterPosZ.
			wValue _ vtx rasterPosW.
			wValue = 0.0 ifFalse:[zValue _ zValue / wValue].
			(minIndex = 0 or:[zValue < minZ]) ifTrue:[
				minIndex _ index.
				minZ _ zValue].
		].
	].
	^minIndex