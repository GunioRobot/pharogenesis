drawImage: aForm on: aCanvas
	"Draw the given form onto the canvas using the Balloon 3D engine"
	| engine |
	engine _ (B3DRenderEngine defaultForPlatformOn: aCanvas form).
	engine == nil ifTrue:[^self].
	"Setup the engine"
	engine viewport: aCanvas form boundingBox.
	"Install the material to be used (using a plain white emission color)"
	engine material: (B3DMaterial new emission: Color white).
	"Install the texture"
	engine texture: aForm.
	"Draw the mesh"
	engine render: (B3DIndexedQuadMesh new plainTextureRect).
	"and finish"
	engine finish.