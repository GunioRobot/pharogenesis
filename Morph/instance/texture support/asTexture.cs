asTexture
	"Represent the receiver as a Wonderland texture."
	| canvas texture dirty hqTexture texExtent tempForm |
	hqTexture _ self valueOfProperty: #highQualityTexture ifAbsent:[false].
	dirty _ self valueOfProperty: #textureIsDirty ifAbsent:[false].
	texture _ self valueOfProperty: #wonderlandTexture.
	"Determine the size we expect the texture to be.
	Note: This size must never be less than the receiver's since
	this will lead to (unwanted) clipping."
	texExtent _ self extent.
	hqTexture ifTrue:[
		"High quality textures round up to next power of two"
		texExtent _ texExtent x asLargerPowerOfTwo @ texExtent y asLargerPowerOfTwo.
	].
	(texture == nil or:[texture extent ~= texExtent]) ifTrue:[
		self removeProperty: #wonderlandTexture.
		texture _ nil. "Clean up for GC"
		texture _ B3DTexture extent: texExtent depth: 32.
		texture interpolate: false.
		texture wrap: false.
		texture envMode: 0.
		dirty _ true].
	dirty ifTrue:[
		canvas _ texture getCanvas.
		canvas translateBy: self topLeft negated
			during:[:tempCanvas| self fullDrawOn: tempCanvas].
		self removeProperty: #textureIsDirty.
		"High quality textures need an extra pass here"
		(texExtent ~= self extent) ifTrue:[
			tempForm _ texture contentsOfArea: (0@0 extent: self extent).
			tempForm displayInterpolatedOn: texture].
	].
	self setProperty: #wonderlandTexture toValue: texture.
	^ texture