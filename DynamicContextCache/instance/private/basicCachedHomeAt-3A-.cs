basicCachedHomeAt: cp
	"For use during GC remapping"
	self inline: true.
	self assertIsCachedContext: cp.
	^self longAt: cp + (CacheHomeIndex * 4)