vrmlCreateConeFaces
	| face steps dir m lastVtx nextVtx topVtx faceList |
	steps _ self vrmlSteps.
	faceList _ WriteStream on: (Array new: steps).
	dir _ 0@0@1.
	m _ (B3DRotation angle: (360.0 / steps) axis: (0@-1@0)) asMatrix4x4.
	lastVtx _ B3DSimpleMeshVertex new.
	lastVtx position: 0@-1@1.
	lastVtx normal: dir.
	lastVtx texCoord: 0@1.
	1 to: steps do:[:i|
		face _ B3DSimpleMeshFace new: 3.
		face at: 1 put: lastVtx.
		dir _ (m localPointToGlobal: dir) normalized.
		nextVtx _ B3DSimpleMeshVertex new.
		nextVtx position: dir x @ -1 @ dir z.
		nextVtx normal: dir.
		nextVtx texCoord: (i / steps asFloat) @ 1.
		topVtx _ nextVtx copy.
		topVtx position: 0@1@0.
		topVtx texCoord:  lastVtx texCoord x @ 0.
		face at: 2 put: nextVtx.
		face at: 3 put: topVtx.
		faceList nextPut: face.
		lastVtx _ nextVtx].
	^faceList contents