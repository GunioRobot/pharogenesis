cachedPseudoContextAt: cp put: aPseudoContext

	self inline: true.
	self assertIsCachedContext: cp.
	self assertIsPseudoContextOrNull: aPseudoContext.
	self longAt: cp + (CachePseudoContextIndex * 4) put: aPseudoContext.