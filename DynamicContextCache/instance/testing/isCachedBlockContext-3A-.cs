isCachedBlockContext: cp
	"Answer if the cached context cp represents a BlockContext"
	self inline: true.

	self assertIsCachedContext: cp.
	^(self cachedHomeAt: cp) ~= 0