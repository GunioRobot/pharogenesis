basicCachedPseudoContextAt: cp put: aPseudoContext
	"For use during GC remapping"
	self inline: true.
	self assertIsCachedContext: cp.
	^self longAt: cp + (CachePseudoContextIndex * 4) put: aPseudoContext