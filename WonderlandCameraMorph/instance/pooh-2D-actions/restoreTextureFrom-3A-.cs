restoreTextureFrom: aForm
	| texture |
	texture _ aForm deepCopy.
	currentActor setTexturePointer: texture.
	currentCanvas setForm: texture.