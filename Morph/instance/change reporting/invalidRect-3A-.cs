invalidRect: damageRect

	owner ifNotNil: [owner invalidRect: damageRect].
	(self hasProperty:#wonderlandTexture) ifTrue:["If I am a wonderland texture"
		self setProperty: #textureIsDirty toValue: true].