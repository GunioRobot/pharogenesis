compilerMapHookFrom: memStart to: memEnd
	self inline: true.
	compilerInitialized ifTrue: [self compilerMapFrom: memStart to: memEnd]