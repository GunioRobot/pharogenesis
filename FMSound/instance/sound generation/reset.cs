reset

	self internalizeModulationAndRatio.
	super reset.
	count _ initialCount.
	scaledIndex _ 0.
	scaledOffsetIndex _ 0.
