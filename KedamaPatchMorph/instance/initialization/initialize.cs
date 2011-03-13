initialize

	super initialize.

	self evaporationRate: 6.
	self diffusionRate: 1.
	self sniffRange: 1.

	displayType _ #logScale.
	displayMax _ WordArray with: 1024.
	shiftAmount _ -2.

	autoChanged _ true.

	self formChanged.
