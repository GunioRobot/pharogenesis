cachedInstructionPointerAt: cp put: rawPointer
"
	| meth index |
	self inline: true.
	self assertIsCachedContext: cp.
	meth _ self cachedMethodAt: cp.
	index _ self integerObjectOf: (rawPointer - meth - BaseHeaderSize + 2).
	self assertIsLegalInstructionIndex: index in: meth.
	self longAt: cp + (CacheInstructionPointerIndex * 4) put: index
"
	self inline: true.
	self assertIsLegalTranslatedInstructionPointer: rawPointer in: (self cachedTranslatedMethodAt: cp).
	self longAt: cp + (CacheInstructionPointerIndex * 4) put: rawPointer