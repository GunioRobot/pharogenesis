basicCachedPseudoContextAt: cp

	self inline: true.
	self assertIsCachedContext: cp.
	^self longAt: cp + (CachePseudoContextIndex * 4)