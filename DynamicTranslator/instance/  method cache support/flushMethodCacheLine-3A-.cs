flushMethodCacheLine: index

	self ejectMethodCacheLine: index.
	"it should really only be necessary to zap the selector slot"
	0 to: MethodCacheColumns - 1 do:
		[:col | methodCache at: index + (MethodCacheEntries * col) put: 0]