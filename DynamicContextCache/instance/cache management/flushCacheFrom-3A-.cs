flushCacheFrom: cp
	"Flush the cache starting at the cached context cp.  Answer the new top context
	in the stable section of the stack.
	Notes:	We flush the cache from the lowestCachedContext to cp inclusive, using
			ejectFromCache: which already implements exactly the required behaviour.
			This method can provoke a GC."

	| ctx done |
	self inline: false.
	self assertIsCachedContext: cp.
	done _ false.
	[done] whileFalse: [
		ctx _ self ejectFromCache: lowestCachedContext.
		done _ lowestCachedContext = cp.
		lowestCachedContext _ self cachedContextAfter: lowestCachedContext.
	].
	self assertIsStableContext: ctx.
	cp = activeCachedContext ifTrue: [activeCachedContext _ lowestCachedContext _ 0].
	^ctx