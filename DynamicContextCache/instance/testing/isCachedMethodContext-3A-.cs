isCachedMethodContext: cp
	"Answer if the cached context cp represents a MethodContext"
	self inline: true.

	self assertIsCachedContext: cp.
	^(self cachedHomeAt: cp) = 0