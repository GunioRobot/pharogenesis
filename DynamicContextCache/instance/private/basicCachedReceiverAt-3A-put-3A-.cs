basicCachedReceiverAt: cp put: anObject
	"For use during GC remapping"
	self inline: true.
	self assertIsCachedContext: cp.
	self longAt: cp + (CacheReceiverIndex * 4) put: anObject