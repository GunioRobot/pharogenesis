cachedContextBefore: contextPointer
	"Answer the address of the context cache frame before contextPointer.  Wrap from the
	bottom context frame around to the top context frame."

	self inline: true.

	self assertIsCachedContext: contextPointer.
	(contextCache = contextPointer) ifTrue: [^lastCachedContext].
	^contextPointer - CacheEntrySize