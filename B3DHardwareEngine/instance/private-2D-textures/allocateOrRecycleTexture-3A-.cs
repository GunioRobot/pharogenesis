allocateOrRecycleTexture: aB3DTexture
	"If a texture for the given one has already been allocated return it. If not, allocate a new texture."
	| texture |
	^textures at: aB3DTexture ifAbsent:[
		texture _ self allocateTexture: aB3DTexture.
		texture ifNotNil:[
			textures at: aB3DTexture put: texture.
			aB3DTexture hasBeenModified: true].
		texture]