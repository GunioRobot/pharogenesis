compilerFlushCacheHook: aCompiledMethod
	self inline: true.
	compilerInitialized ifTrue: [self compilerFlushCache: aCompiledMethod]