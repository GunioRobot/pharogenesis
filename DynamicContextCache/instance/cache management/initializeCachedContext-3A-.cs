initializeCachedContext: cp
	"Init the private fields of cp."

	"cp to: cp + CacheEntrySize - 4 by: 4 do: [:ptr | self longAt: ptr put: nilObj]."

	self inline: true.
	self cachedSenderAt:					cp put: 0.
	self cachedPseudoContextAt:			cp put: 0.
	"self cachedContextReceiverFlagAt:	cp put: 0."	"no longer needed"