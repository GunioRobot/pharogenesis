textureHandleOf: aTexture
	| textureForm |
	aTexture ifNil:[^-1].
	textureForm _ self allocateOrRecycleTexture: aTexture.
	textureForm ifNil:[^-1].
	"Update textureForm if aTexture is dirty"
	aTexture hasBeenModified ifTrue:[
		"Use the best method we have"
		textureForm prepareForUpload.
		"@@@ FIXME: We need to fix displayOn: etc. to deal with color maps @@@"
		textureForm extent = aTexture extent ifTrue:[
			self displayForm: aTexture on: textureForm.
		] ifFalse:[aTexture displayInterpolatedOn: textureForm].
		self uploadTexture: textureForm.
		textureForm releaseFromUpload.
		aTexture hasBeenModified: false].
	^textureForm getExternalHandle