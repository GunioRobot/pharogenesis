cacheSize
	"Answer the size (in bytes) of the all caches."

	self inline: true.

	^self contextCacheSize + self stackCacheSize