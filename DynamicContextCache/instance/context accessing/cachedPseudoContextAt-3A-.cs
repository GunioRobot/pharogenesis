cachedPseudoContextAt: cp

	self inline: true.
	self assertIsCachedContext: cp.
	self assertIsPseudoContextOrNull: (self longAt: cp + (CachePseudoContextIndex * 4)).
	self assertIsValidPseudoContextAt: cp.
	^self longAt: cp + (CachePseudoContextIndex * 4)