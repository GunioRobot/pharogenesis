pseudoContextFor: cp
	"Answer the PseudoContext for cp.  Create one if necessary.
	Notes:	This method can provoke a GC."

	| pc |
	self inline: true.
	self assertIsCachedContext: cp.
	pc _ self cachedPseudoContextAt: cp.
	pc = 0 ifTrue: [pc _ self allocatePseudoContextFor: cp].
	self assertIsPseudoContext: pc.
	^pc