transformBy: aMatrix
	"Modify the mesh by transforming it using a matrix; this allows us to change the insertion point of the mesh"
	| transformer primVtx |
	transformer _ B3DPrimitiveTransformer new.
	primVtx _ B3DPrimitiveVertex new.
	vertices _ vertices clone.
	vertices do:[:vtx|
		primVtx position: vtx.
		transformer privateTransformPrimitiveVertex: primVtx byModelView: aMatrix.
		vtx loadFrom: primVtx position].
	vtxNormals ifNotNil:[
		vtxNormals _ vtxNormals clone.
		vtxNormals do:[:nrm|
			primVtx normal: nrm.
			transformer privateTransformPrimitiveNormal: primVtx byMatrix: aMatrix rescale: true.
			nrm loadFrom: primVtx normal]].

	bBox ifNotNil: [bBox _ self computeBoundingBox].