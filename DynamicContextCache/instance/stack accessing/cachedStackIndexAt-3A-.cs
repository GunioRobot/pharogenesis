cachedStackIndexAt: cp
	"Answer Smalltalk's index for the stack pointer in cp."

	self inline: true.
	self assertIsCachedContext: cp.
	^self integerObjectOf: (self cachedStackPointerAt: cp) - (self cachedFramePointerAt: cp) // 4 + 1