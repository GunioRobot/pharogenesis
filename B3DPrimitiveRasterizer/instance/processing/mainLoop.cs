mainLoop
	"Do the actual rasterization"
	| errCode objects textureArray |
	objects _ primObjects contents.
	objects size = 0 ifTrue:[^self]. "Nothing to do"
	textureArray _ Array new: textures size.
	textures associationsDo:[:assoc| textureArray at: assoc value put: assoc key].
	state initObjects: objects size.
	state initTextures: textureArray size.
	textureArray do:[:tex| tex unhibernate].
	[errCode _ self primStartRasterizer: state objects: objects textures: textureArray.
	errCode = 0] whileFalse:[
		"Not yet finished"
		self processErrorCode: (errCode bitAnd: 255).
		state reset].
	primObjects reset.
	textures _ IdentityDictionary new: textures capacity.
	false ifTrue:[self printSpaceUsage: objects].
