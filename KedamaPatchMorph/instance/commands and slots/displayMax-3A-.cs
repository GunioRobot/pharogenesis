displayMax: anInteger

	displayMax _ WordArray with: (anInteger asInteger min: 16rFFFFFFFF max: 0).
	self formChanged.
