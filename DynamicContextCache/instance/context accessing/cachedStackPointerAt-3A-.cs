cachedStackPointerAt: cp
	"Answer the raw stack pointer for the given context"

	self inline: true.
	self assertIsCachedContext: cp.
	^self longAt: cp + (CacheStackPointerIndex * 4)