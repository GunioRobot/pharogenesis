setTexturePointer: texture
	"Sets the object's texture"
	myTexture _ texture.
	self partsDo:[:part| part setTexturePointer: texture].
