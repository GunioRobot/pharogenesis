initialize
	super initialize.
	literals _ ByteArray new: WindowSize.
	distances _ WordArray new: WindowSize.
	literalFreq _ WordArray new: MaxLiteralCodes.
	distanceFreq _ WordArray new: MaxDistCodes.
	self initializeNewBlock.
