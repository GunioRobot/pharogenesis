textureHandleOf: aTexture
	| textureForm |
	aTexture ifNil:[^-1].
	textureForm _ self allocateOrRecycleTexture: aTexture.
	textureForm ifNil:[^-1].
	"Update textureForm if aTexture is dirty"
	aTexture hasBeenModified ifTrue:[
		"Use the best method we have"
		aTexture displayInterpolatedOn: textureForm.
		aTexture hasBeenModified: false].
	^textureForm getExternalHandle