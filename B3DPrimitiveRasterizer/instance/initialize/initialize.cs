initialize
	super initialize.
	primObjects _ WriteStream on: (Array new: 100).
	state _ B3DPrimitiveRasterizerState new.
	state initialize.
	textures _ IdentityDictionary new: 33.