drawMesh: aRenderer
	"Draw the mesh for this actor."

	myMaterial ifNotNil: [
			aRenderer pushMaterial.
			aRenderer material: myMaterial.
						].

	myTexture ifNotNil: [
			aRenderer pushTexture.
			aRenderer texture: myTexture.
						].

	"Note from Andreas: Using myMesh>>renderOn: here prevents meshes
		from being picked!"
	myMesh ifNotNil: [ myMesh renderOn: aRenderer ].

	myTexture ifNotNil: [ aRenderer popTexture ].

	myMaterial ifNotNil: [ aRenderer popMaterial ].
