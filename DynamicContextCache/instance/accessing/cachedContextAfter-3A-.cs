cachedContextAfter: contextPointer
	"Answer the address of the context cache frame after contextPointer.  Wrap from the
	top context frame around to the bottom context frame."

	self inline: true.

	self assertIsCachedContext: contextPointer.
	lastCachedContext = contextPointer ifTrue: [^contextCache].
	^contextPointer + CacheEntrySize