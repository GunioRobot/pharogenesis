initialize
	super initialize.
	textures _ IdentityDictionary new: 37.
	backingForm _ B3DBackingForm extent: 64@64 depth: 32.