cachedInstructionPointerAt: cp
"
	| meth index ip |
	self inline: true.
	self assertIsCachedContext: cp.
	meth _ self cachedMethodAt: cp.
	index _ self longAt: cp + (CacheInstructionPointerIndex * 4).
	self assertIsIntegerObject: index.
	index _ self integerValueOf: index.
	ip _ meth + BaseHeaderSize + index - 2.
	self assertIsLegalInstructionPointer: ip in: meth.
	^ip
"
	self inline: true.
	self assertIsCachedContext: cp.
	self assertIsLegalTranslatedInstructionPointer: (self longAt: cp + (CacheInstructionPointerIndex * 4))
		in: (self cachedTranslatedMethodAt: cp).
	^self longAt: cp + (CacheInstructionPointerIndex * 4)