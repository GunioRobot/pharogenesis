compilerTranslateMethodHook
	self inline: true.
	^compilerInitialized and: [self compilerTranslateMethod]