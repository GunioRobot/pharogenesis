newActiveContext: aContext

	self storeContextRegisters: activeContext.
	(aContext < youngStart) ifTrue: [ self beRootIfOld: aContext ].
	activeContext _ aContext.
	self fetchContextRegisters: aContext.