initializeFor: aWonderland
	"Initialize the light"

	super initializeFor: aWonderland.

	"Set the light's mesh and texture"
	self setMesh: (WonderlandConstants at: 'lightMesh').
	self setTexturePointer: (WonderlandConstants at: 'lightTexture').

	lightColor _ B3DMaterialColor new.
	self setColorVector: (B3DColor4 r: 1.0 g: 1.0 b: 1.0 a: 1.0).
