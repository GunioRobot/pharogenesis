vrmlCreateBoxFaces
	| vtx face vtxSpec faceList |
	faceList _ WriteStream on: (Array new: 6).
	"front and back face"
	vtxSpec _ #(	((-1 -1) (0 1))	(( 1 -1) (1 1))		(( 1  1) (1 0))	((-1  1) (0 0))).
	"front"
	face _ B3DSimpleMeshFace new: 4.
	vtxSpec doWithIndex:[:spec :idx|
		vtx _ B3DSimpleMeshVertex new.
		vtx position: spec first first @ spec first second @ -1.
		vtx normal: 0@0@-1.
		vtx texCoord: spec second first @ spec second second.
		face at: idx put: vtx.
	].
	faceList nextPut: face.
	"back"
	face _ B3DSimpleMeshFace new: 4.
	vtxSpec doWithIndex:[:spec :idx|
		vtx _ B3DSimpleMeshVertex new.
		vtx position: spec first first @ spec first second @ 1.
		vtx normal: 0@0@1.
		vtx texCoord: 1 - spec second first @ spec second second.
		face at: idx put: vtx.
	].
	faceList nextPut: face.
	"top"
	face _ B3DSimpleMeshFace new: 4.
	vtxSpec doWithIndex:[:spec :idx|
		vtx _ B3DSimpleMeshVertex new.
		vtx position: spec first first @ 1 @ spec first second.
		vtx normal: 1@0@0.
		vtx texCoord: spec second first @ spec second second.
		face at: idx put: vtx.
	].
	faceList nextPut: face.
	"bottom"
	face _ B3DSimpleMeshFace new: 4.
	vtxSpec doWithIndex:[:spec :idx|
		vtx _ B3DSimpleMeshVertex new.
		vtx position: spec first first @ -1 @ spec first second.
		vtx normal: -1@0@0.
		vtx texCoord: spec second first @ (1 - spec second second).
		face at: idx put: vtx.
	].
	faceList nextPut: face.
	vtxSpec _ #(	((-1 -1) (0 1))	((-1  1) (1 1))		(( 1  1) (1 0))	(( 1 -1) (0 0))).
	"right"
	face _ B3DSimpleMeshFace new: 4.
	vtxSpec doWithIndex:[:spec :idx|
		vtx _ B3DSimpleMeshVertex new.
		vtx position: 1 @ spec first first @ spec first second.
		vtx normal: 1@0@0.
		vtx texCoord: spec second first @ spec second second.
		face at: idx put: vtx.
	].
	faceList nextPut: face.
	"left"
	face _ B3DSimpleMeshFace new: 4.
	vtxSpec doWithIndex:[:spec :idx|
		vtx _ B3DSimpleMeshVertex new.
		vtx position: -1 @ spec first first @ spec first second.
		vtx normal: -1@0@0.
		vtx texCoord: 1 - spec second first @ spec second second.
		face at: idx put: vtx.
	].
	faceList nextPut: face.
	^faceList contents