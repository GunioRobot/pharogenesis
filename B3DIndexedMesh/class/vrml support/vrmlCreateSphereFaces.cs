vrmlCreateSphereFaces
	"B3DIndexedMesh vrmlCreateSphereFaces"
	| faceList vtx steps m1 m2 baseDir vtxList vertices dir lastVtx nextVtx face |
	steps _ self vrmlSteps.
	faceList _ WriteStream on: (Array new: steps * steps).
	"<--- vertex construction --->"
	m1 _ (B3DRotation angle: 360.0 / steps axis: 0@-1@0) asMatrix4x4.
	m2 _ (B3DRotation angle: 180.0 / steps axis: 1@0@0) asMatrix4x4.
	baseDir _ 0@1@0.
	vtxList _ Array new: steps + 1.
	0 to: steps do:[:i|
		i = steps ifTrue:[baseDir _ 0@-1@0]. "Make closed for sure"
		vertices _ Array new: steps + 1.
		vtxList at: i+1 put: vertices.
		dir _ baseDir.
		0 to: steps do:[:j|
			j = steps ifTrue:[dir _ baseDir]. "Make closed for sure"
			vtx _ B3DSimpleMeshVertex new.
			vtx position: dir; normal: dir.
			vtx texCoord: (j / steps asFloat) @ (i / steps asFloat).
			vertices at: j+1 put: vtx.
			dir _ (m1 localPointToGlobal: dir) normalized.
		].
		baseDir _ (m2 localPointToGlobal: baseDir) normalized.
	].
	"<--- face construction --->"
	"Construct first round separately as triangles"
	lastVtx _ vtxList at: 1.
	nextVtx _ vtxList at: 2.
	1 to: steps do:[:i|
		face _ B3DSimpleMeshFace new: 3.
		face at: 1 put: (lastVtx at: i).
		face at: 2 put: (nextVtx at: i+1).
		face at: 3 put: (nextVtx at: i).
		faceList nextPut: face].
	"Construct the next rounds as quads"
	2 to: steps-1 do:[:i|
		lastVtx _ vtxList at: i.
		nextVtx _ vtxList at: i+1.
		1 to: steps do:[:j|
			face _ B3DSimpleMeshFace new: 4.
			face at: 1 put: (lastVtx at: j).
			face at: 2 put: (lastVtx at: j+1).
			face at: 3 put: (nextVtx at: j+1).
			face at: 4 put: (nextVtx at: j).
			faceList nextPut: face]].
	"Construct the last round separately as triangles"
	lastVtx _ vtxList at: steps.
	nextVtx _ vtxList at: steps+1.
	1 to: steps do:[:i|
		face _ B3DSimpleMeshFace new: 3.
		face at: 1 put: (lastVtx at: i).
		face at: 2 put: (lastVtx at: i+1).
		face at: 3 put: (nextVtx at: i).
		faceList nextPut: face].
	^faceList contents