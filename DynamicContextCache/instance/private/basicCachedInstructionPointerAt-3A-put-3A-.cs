basicCachedInstructionPointerAt: cp put: ip
	"For use during GC remapping"
	self inline: true.
	self assertIsCachedContext: cp.
	^self longAt: cp + (CacheInstructionPointerIndex * 4) put: ip.