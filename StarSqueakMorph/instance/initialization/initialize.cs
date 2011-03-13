initialize

	super initialize.
	dimensions := self starSqueakDimensions.  "dimensions of this StarSqueak world in patches"
	pixelsPerPatch := 2.
	super extent: dimensions * pixelsPerPatch.
	self evaporationRate: 6.
	self diffusionRate: 1.
	self clearAll.  "be sure this is done once in case setup fails to do it"
	self setup.
