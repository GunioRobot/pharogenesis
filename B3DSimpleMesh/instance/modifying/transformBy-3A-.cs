transformBy: aMatrix
"	| transformer primVtx |
	transformer _ B3DPrimitiveTransformer new.
	primVtx _ B3DPrimitiveVertex new.
	vertices do:[:vtx|
		primVtx position: vtx.
		transformer privateTransformPrimitiveVertex: primVtx byModelView: aMatrix.
		vtx loadFrom: primVtx position].
	vtxNormals ifNotNil:[
		vtxNormals do:[:nrm|
			primVtx normal: nrm.
			transformer privateTransformPrimitiveNormal: primVtx byMatrix: aMatrix rescale: true.
			nrm loadFrom: primVtx normal]].

	bBox ifNotNil: [bBox _ self computeBoundingBox].
	vtxNormals ifNil:[self computeVertexNormals]."