cachedFramePointerAt: cp put: fp
	"Answer the frame pointer for the given context"

	self inline: true.
	self assertIsCachedContext: cp.
	^self longAt: cp + (CacheFramePointerIndex * 4) put: fp