initialiseModule
	self export: true.
	self initBBOpTable.
	self initDither8Lookup.
	^true