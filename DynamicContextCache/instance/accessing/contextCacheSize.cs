contextCacheSize
	"Answer the size (in bytes) of the context cache."
	self inline: true.

	^contextCacheEntries * CacheEntrySize