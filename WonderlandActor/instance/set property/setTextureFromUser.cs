setTextureFromUser
	"Set the texture from the user"
	| form |
	form _ Form fromUser.
	self setTexturePointer: form asTexture.