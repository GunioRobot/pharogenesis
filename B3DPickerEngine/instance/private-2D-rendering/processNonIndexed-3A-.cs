processNonIndexed: vb
	| vtxArray vtx zValue minZ minIndex wValue |
	vtxArray _ vb vertexArray.
	minZ _ 10.0.
	minIndex _ 0.
	1 to: vb vertexCount do:[:i|
		vtx _ vtxArray at: i.
		zValue _ vtx rasterPosZ.
		wValue _ vtx rasterPosW.
		wValue = 0.0 ifFalse:[zValue _ zValue / wValue].
		(minIndex = 0 or:[zValue < minZ]) ifTrue:[
			minIndex _ i.
			minZ _ zValue].
	].
	^minIndex