step

	InterpreterLog logToTranscript.
	byteCount _ 0.
	self internalizeIPandSP.
	[true] whileTrue: [
		self assertStackPointerIsInternal.
		currentBytecode _ self fetchInstruction.
		"InterpreterLog>>endEntry is called at every context change"
		InterpreterLog isActive ifTrue:
			[InterpreterLog cr; nextPutAll: (self printExecutionState)].
		self singleStep.
		self dispatchOn: currentBytecode in: OpcodeTable.
		self assertIsLegalStackPointer: localSP.
		self assertIsLegalTempPointer: self temporaryPointer.
		(byteCount _ byteCount + 1)" == 7000 ifTrue: [self halt]".
	].
	self externalizeIPandSP.
