drawMesh: aRenderer
	"Draw the mesh for this actor."
	| recorder bounds |

	myMaterial ifNotNil: [
			aRenderer pushMaterial.
			aRenderer material: myMaterial.
						].

	myTexture ifNotNil: [
			aRenderer pushTexture.
			aRenderer texture: myTexture.
						].

	"Note: Using myMesh>>renderOn: here prevents meshes from being picked!"
	myMesh ifNotNil: [ bounds _ myMesh renderOn: aRenderer].

	myTexture ifNotNil: [ aRenderer popTexture ].

	myMaterial ifNotNil: [ aRenderer popMaterial ].

	"Pass the 2D extent back to the recorder (if any)"
	recorder _ aRenderer valueOfProperty: #boundsRecorder.
	recorder == nil ifFalse:[recorder setBounds: bounds for: self].