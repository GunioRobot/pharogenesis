deallocateCachedContext
	"Deallocate the top cached context, setting activeCachedContext to the appropriate new value.
	If the old activeCachedContext has a pseudo context, copy its state into the pseudo context,
	but leave the sender field nil.  If the context cache underflows, copy the topmost stable
	context into the cache and reset activeCachedContext and lowestCachedContext appropriately.
	If the new activeCachedContext is a block context with a stable home, make the home a root
	if it is in old space."

	| cp pc |
	self inline: true.
	cp _ activeCachedContext.
	pc _ self cachedPseudoContextAt: cp.
	pc = 0 ifFalse: [
		self assertIsValidPseudoContextAt: cp.
		self copyCache: cp toPseudoContext: pc setSender: false.
		self cachedPseudoContextAt: cp put: 0.	"sane value for future allocations"
	].
	cp = lowestCachedContext ifTrue: [
		self copyContextToCache: (self cachedSenderAt: cp).
	] ifFalse: [
		cp _ self cachedContextBefore: cp.
		activeCachedContext _ cp.
	].