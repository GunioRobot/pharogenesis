deallocateAllCachedContexts
	"Deallocate the all cached contexts, resetting activeCachedContext to indicate the absence of
	any active context.  If any cached context has a pseudo context, copy its state into the
	pseudo context, but leave the sender field nil.  Answer the topmost stable context.
	Notes:	It is the caller's responsibility to reinitialise the cache for subsequent execution."

	| cp pc stableContext |
	self inline: false.
	cp _ activeCachedContext.
	[cp = 0] whileFalse: [
		stableContext _ self cachedSenderAt: cp.
		pc _ self cachedPseudoContextAt: cp.
		pc = 0 ifFalse: [
			self assertIsValidPseudoContextAt: cp.
			self copyCache: cp toPseudoContext: pc setSender: false.
			self cachedPseudoContextAt: cp put: 0.	"sane value for future allocations"
		].
		cp = lowestCachedContext
			ifTrue: [cp _ 0]
			ifFalse: [cp _ self cachedContextBefore: cp].
	].
	activeCachedContext _ 0.
	^stableContext