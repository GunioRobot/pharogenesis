internalActivateNewMethod
	self inline: true.
	compilerInitialized
		ifTrue: 
			[self externalizeIPandSP.
			 self activateNewMethod.
			 self internalizeIPandSP]
		ifFalse:
			[self internalBytecodeActivateNewMethod]