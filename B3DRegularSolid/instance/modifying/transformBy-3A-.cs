transformBy: aMatrix
  " this method assumes
     1. that vertices does not contain shared instances,
     2. that vertexNormals does not contain shared instances,
     3. that faceNormals does not contain shared instances. 
    Any shared instances would be transformed more than once, which is clearly wrong. "

	| transformer primVtx |
	transformer _ B3DPrimitiveTransformer new.
	primVtx _ B3DPrimitiveVertex new.
	vertices do:[:vtx|
		primVtx position: vtx.
		transformer privateTransformPrimitiveVertex: primVtx byModelView: aMatrix.
		vtx loadFrom: primVtx position].
	vertexNormals ifNotNil:[
		vertexNormals do:[:nrm|
			primVtx normal: nrm.
			transformer privateTransformPrimitiveNormal: primVtx byMatrix: aMatrix rescale: true.
			nrm loadFrom: primVtx normal]].
	faceNormals ifNotNil:[
		faceNormals do:[:nrm|
			primVtx normal: nrm.
			transformer privateTransformPrimitiveNormal: primVtx byMatrix: aMatrix rescale: true.
			nrm loadFrom: primVtx normal]].

	bBox _ self computeBoundingBox.
	"vtxNormals ifNil:[self computeVertexNormals]."