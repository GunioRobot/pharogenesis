allocatePseudoContextFor: cp
	"Answer the PseudoContext for cp.  Create one if necessary.
	Notes:	This method can provoke a GC."

	| pc methodHeader smallContext meth |
	self inline: false.
	self assertIsCachedContext: cp.
	meth _ self cachedMethodAt: cp.
	methodHeader _ self headerOf: meth.
	smallContext _ ((methodHeader >> 18) bitAnd: 1) = 0.
	smallContext ifTrue: [
		pc _ self instantiateSmallClass: (self splObj: ClassPseudoContext) sizeInBytes: SmallContextSize fill: nilObj.
	] ifFalse: [
		pc _ self instantiateSmallClass: (self splObj: ClassPseudoContext) sizeInBytes: LargeContextSize fill: nilObj.
	].
	"The cached context and associated pseudo context contain back pointers to each other."
	self pseudoCachedContextAt: pc put: cp.
	self cachedPseudoContextAt: cp put: pc.
	self assertIsValidPseudoContextAt: cp.
	^pc