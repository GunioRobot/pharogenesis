test
	Transcript clear.
	byteCount _ 0.
	quitBlock _ [^ self].
	self internalizeIPandSP.
	self fetchNextBytecode.
	[true] whileTrue:
		[self dispatchOn: currentBytecode in: BytecodeTable.
		byteCount _ byteCount + 1].
	self externalizeIPandSP.
