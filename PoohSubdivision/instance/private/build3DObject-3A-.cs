build3DObject: twoSided
	"Return the full triangulation of the receiver"
	| firstPoly poly faces mesh half vtx nrm texScale |
	self markExteriorEdges.
	firstPoly _ self triangulate.
	faces _ WriteStream on: #().
	poly _ firstPoly.
	[poly == nil] whileFalse:[
		faces nextPutAll: (poly elevateSpine: 2).
		poly _ poly next].
	faces _ faces contents.
	faces isEmpty ifTrue:[^nil].
	half _ B3DSimpleMesh withAll: faces contents.
	texScale _ 1.0 / (area width max: area height).
	twoSided 
		ifTrue:[texScale _ texScale @ (0.5 * texScale)]
		ifFalse:[texScale _ (1.0 / area width) @ (1.0 / area height)].
	half do:[:face| face do:[:v|
		v texCoord: (v position x @ v position y) - area origin * texScale]].
	half _ half asIndexedMesh.
	half vertexNormals: (half computeVertexNormals collect:[:v| v negated]).
	vtx _ half vertices.
	nrm _ half vertexNormals.
	1 to: vtx size do:[:i|
		(vtx at: i) z = 0.0 ifTrue:[nrm at: i put: ((nrm at: i) z: 0.0)]].
	mesh _ self mirror: half twoSided: twoSided.
	^mesh