compilerPreGCHook: fullGCFlag
	self inline: true.
	compilerInitialized ifTrue: [self compilerPreGC: fullGCFlag]