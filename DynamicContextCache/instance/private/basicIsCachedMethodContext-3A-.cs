basicIsCachedMethodContext: cp
	"For use during GC remapping"

	self inline: true.
	self assertIsCachedContext: cp.
	^(self basicCachedHomeAt: cp) = 0