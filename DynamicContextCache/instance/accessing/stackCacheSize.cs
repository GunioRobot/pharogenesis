stackCacheSize
	"Answer the size (in bytes) of the stack cache."
	self inline: true.

	^stackCacheEntries * StackEntrySize