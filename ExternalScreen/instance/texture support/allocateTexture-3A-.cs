allocateTexture: aB3DTexture
	"Allocate a new texture for the given (Squeak internal) form.
	NOTE: The size/depth of the texture allocated can differ. Right now
	there's an implicit strategy in the primitive code for choosing the
	right tradeoff between speed and space. In the optimal case this
	will result in a texture which is 'good enough' for what we have
	but if that can't be achieved anything might come back.
		Also, textures might be subject to certain restrictions. Some 
	graphics cards have minimum/maximum sizes of textures (some 
	older even require squared textures) and this needs to be taken
	into account by the primitive.
		One thing that's currently not handled is if insufficient
	memory is encountered. This can happen if there's just not enough
	VRAM or AGP memory. A good idea would be to free up some of
	the already allocated textures but it's not quite sure if that'll do
	the trick and it would require flushing the renderer. Tricky."
	| textureHandle |
	textureHandle _ self primAllocateTexture: aB3DTexture depth width: aB3DTexture width height: aB3DTexture height.
	textureHandle = nil ifTrue:[^nil].
	"And return the allocated texture.
	Note: #setExternalHandle: will automatically check for w/h/d"
	^(ExternalTexture initializeFrom: aB3DTexture) setExternalHandle: textureHandle on: self