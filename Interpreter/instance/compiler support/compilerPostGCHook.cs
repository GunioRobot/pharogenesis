compilerPostGCHook
	self inline: true.
	compilerInitialized ifTrue: [self compilerPostGC]