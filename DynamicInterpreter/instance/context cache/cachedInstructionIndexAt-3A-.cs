cachedInstructionIndexAt: cp
"
	| result |
	self inline: true.
	self assertIsCachedContext: cp.
	result _ self longAt: cp + (CacheInstructionPointerIndex * 4).
	self assertIsIntegerObject: result.
	^result
"
	| meth index ip |
	self inline: true.
	ip _ self cachedInstructionPointerAt: cp.
	meth _ self cachedTranslatedMethodAt: cp.
	index _ self translatedInstructionPointer: ip toIndexIn: meth.
	self assertIsLegalTranslatedInstructionIndex: index in: meth.
	^index
