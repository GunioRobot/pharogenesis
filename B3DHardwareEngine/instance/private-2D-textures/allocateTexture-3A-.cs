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
	| textureHandle w h d rgbaBitMasks msbFlag textureBits |
	w _ aB3DTexture width asSmallerPowerOfTwo.
	h _ aB3DTexture height asSmallerPowerOfTwo.
	textureHandle _ self primRender: handle allocateTexture: aB3DTexture depth width: w height: h.
	textureHandle = nil ifTrue:[^nil].
	d _ self primRender: handle getTextureDepth: textureHandle.
	rgbaBitMasks _ Array new: 4.
	self primRender: handle texture: textureHandle colorMasksInto: rgbaBitMasks.
	msbFlag _ self primRender: handle getTextureByteSex: textureHandle.
	textureBits _ self primRender: handle getTextureSurface: textureHandle.
	textureBits ifNil:[
		d _ d abs.
		textureBits _ Bitmap new. "empty shadow bitmap"
	] ifNotNil:[
		msbFlag = (d > 0) ifFalse:[d _ 0 - d].
	].
	"And return the allocated texture"
	^(B3DHardwareTexture new initializeFrom: aB3DTexture) 
		setExtent: w@h depth: d bits: textureBits 
		rgbaBitMasks: rgbaBitMasks handle: textureHandle renderer: self.