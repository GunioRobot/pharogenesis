activateNewMethod

	self inline: true.
	self compilerActivateMethodHook
		ifFalse: [self bytecodeActivateNewMethod].