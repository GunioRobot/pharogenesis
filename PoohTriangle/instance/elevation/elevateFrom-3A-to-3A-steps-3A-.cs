elevateFrom: baseVertex to: elevationVertex steps: nSteps
	| centerVertex nrm rot vtxList vtx vertex zScale dirVtx |
	centerVertex _ elevationVertex x @ elevationVertex y @ 0.
	dirVtx _ baseVertex - centerVertex.
	zScale _ elevationVertex z / dirVtx length.
	zScale _ B3DMatrix4x4 withScale: 1@1@zScale.
	nrm _ dirVtx y @ dirVtx x negated @ 0.
	vtxList _ Array new: nSteps+1.
	0 to: nSteps do:[:i|
		i = 0 ifTrue:[
			vtx _ baseVertex.
		] ifFalse:[i = nSteps ifTrue:[
			vtx _ elevationVertex.
		] ifFalse:[
			rot _ (B3DRotation angle: 90.0 * i / nSteps axis: nrm) asMatrix4x4
					composedWithGlobal: zScale.
			vtx _ rot localPointToGlobal: dirVtx.
			vtx _ vtx + centerVertex.
		]].
		vertex _ B3DSimpleMeshVertex new.
		vertex position: vtx.
		vertex normal: B3DVector3 new.
		"vertex normal: (vtx - centerVertex) normalized."
		vtxList at: i+1 put: vertex].
	^vtxList