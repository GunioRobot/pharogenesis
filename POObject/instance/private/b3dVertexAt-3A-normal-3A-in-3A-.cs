b3dVertexAt: aB3DVector normal: norm in: extent
	| vertex tpos center uc vc |
	vertex _ B3DSimpleMeshVertex new position: aB3DVector.
	center _ extent * 0.5.
	uc _ ((center x + aB3DVector x / extent x * 0.5) min: 0.5) max: 0.0.
	vc _ ((center y + aB3DVector y / extent y) min: 1.0) max: 0.0.
	tpos _ B3DVector2 u: uc v: vc.
	vertex texCoord: tpos.
	vertex normal: norm.
	^ vertex
