makeTextureFrom: filename flipping: aBool
	"Create a texture from the given file name and flip it in y if requested"
	| tex |
	filename == nil ifTrue:[^nil].
	^self getSharedTextureDict at: filename ifAbsentPut:[
		tex _ (Form fromFileNamed: filename) asTexture.
		aBool ifTrue:[tex flipVertically].
		tex wrap: true.
		tex interpolate: true.
		tex envMode: 0.
	].
