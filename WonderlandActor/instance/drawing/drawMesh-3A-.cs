drawMesh: aRenderer
	"Draw the mesh for this actor."
	| polyMode |
	myMaterial ifNotNil: [
			aRenderer pushMaterial.
			aRenderer material: myMaterial.
						].

	myTexture ifNotNil: [
			aRenderer pushTexture.
			aRenderer texture: myTexture.
						].
	aRenderer cullFace: self getBackfaceCulling.
	polyMode _ self getPolygonMode.
	aRenderer polygonMode: polyMode.
	polyMode == nil ifFalse:[
		aRenderer lineWidth: self getLineWidth.
		aRenderer pointSize: self getPointSize.
	].
	"Note: Using myMesh>>renderOn: here prevents meshes from being picked!"
	myMesh ifNotNil: [ myMesh renderOn: aRenderer].

	myTexture ifNotNil: [ aRenderer popTexture ].

	myMaterial ifNotNil: [ aRenderer popMaterial ].
