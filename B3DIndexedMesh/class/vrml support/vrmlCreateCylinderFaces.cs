vrmlCreateCylinderFaces
	| face steps dir m lastVtx nextVtx topVtx lastTopVtx faceList |
	steps _ self vrmlSteps.
	faceList _ WriteStream on: (Array new: steps).
	dir _ 0@0@1.
	m _ (B3DRotation angle: (360.0 / steps) axis: (0@-1@0)) asMatrix4x4.
	lastVtx _ B3DSimpleMeshVertex new.
	lastVtx position: 0@-1@1.
	lastVtx normal: dir.
	lastVtx texCoord: 0@1.
	lastTopVtx _ lastVtx copy.
	lastTopVtx position: 0@1@1.
	lastTopVtx texCoord: 0@0.
	1 to: steps do:[:i|
		face _ B3DSimpleMeshFace new: 4.
		face at: 1 put: lastVtx.
		face at: 4 put: lastTopVtx.
		dir _ (m localPointToGlobal: dir) normalized.
		nextVtx _ B3DSimpleMeshVertex new.
		nextVtx position: dir x @ -1 @ dir z.
		nextVtx normal: dir.
		nextVtx texCoord: (i / steps asFloat) @ 1.
		topVtx _ nextVtx copy.
		topVtx position: dir x @ 1 @  dir z.
		topVtx texCoord:  (i / steps asFloat) @ 0.
		face at: 2 put: nextVtx.
		face at: 3 put: topVtx.
		faceList nextPut: face.
		lastVtx _ nextVtx.
		lastTopVtx _ topVtx].
	^faceList contents
