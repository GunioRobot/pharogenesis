loadVerticesFrom: vb
	| out vtxArray |
	vtxArray _ vb vertexArray.
	out _ Array new: vb vertexCount.
	1 to: vb vertexCount do:[:i|
		out at: i put: (vtxArray at: i).
	].
	^out