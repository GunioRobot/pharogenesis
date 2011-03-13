runForNBytes: nBytecodes
	byteCount _ 0.
	self internalizeIPandSP.
	self fetchNextBytecode.
	[byteCount < nBytecodes] whileTrue:
		[self dispatchOn: currentBytecode in: BytecodeTable.
		byteCount _ byteCount + 1].
	self externalizeIPandSP.
