compilerProcessChangeHook
	self inline: true.
	compilerInitialized ifTrue: [self compilerProcessChange]