assertIsPseudoActiveContext: t1 
	self inline: false.
	self assertIsOop: t1.
	t1 == (self cachedPseudoContextAt: activeCachedContext) ifFalse: [self error: 'active PseudoContext expected']