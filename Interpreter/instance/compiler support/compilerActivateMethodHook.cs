compilerActivateMethodHook
	self inline: true.
	^compilerInitialized and: [self compilerActivateMethod]