internalNewActiveContext: aContext
	"The only difference between this method and newActiveContext: is that this method uses internal context registers."
	self inline: true.

	self internalStoreContextRegisters: activeContext.
	(aContext < youngStart) ifTrue: [ self beRootIfOld: aContext ].
	activeContext _ aContext.
	self internalFetchContextRegisters: aContext.