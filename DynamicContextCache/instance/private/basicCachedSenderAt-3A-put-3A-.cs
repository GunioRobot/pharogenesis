basicCachedSenderAt: cp put: aContext
	"For use during GC remapping"
	self inline: true.
	self assertIsCachedContext: cp.
	self longAt: cp + (CacheSenderIndex * 4) put: aContext