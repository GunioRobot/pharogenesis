allocateOrRecycleTexture: aB3DTexture
	"If a texture for the given one has already been allocated return it. If not, allocate a new texture."
	| texture |
	allocatedForms lock. "Rendering may begin any time"
	^allocatedForms at: aB3DTexture ifAbsent:[
		texture _ self allocateTexture: aB3DTexture.
		texture ifNotNil:[
			allocatedForms at: aB3DTexture put: texture.
			aB3DTexture hasBeenModified: true].
		texture]