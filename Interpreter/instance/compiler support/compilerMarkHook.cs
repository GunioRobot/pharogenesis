compilerMarkHook
	self inline: true.
	compilerInitialized ifTrue: [self compilerMark]