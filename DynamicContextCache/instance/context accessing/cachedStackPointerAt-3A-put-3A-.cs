cachedStackPointerAt: cp put: rawPointer
	"Store the stack pointer in the given context"

	self inline: true.
	self assertIsCachedContext: cp.
	self longAt: cp + (CacheStackPointerIndex * 4) put: rawPointer