trace

	InterpreterLog logToTranscript.
	byteCount _ 0.
	self internalizeIPandSP.
	[true] whileTrue: [
		self assertStackPointerIsInternal.
		currentBytecode _ self fetchInstruction.
		"InterpreterLog>>endEntry is called at every context change -- only do it below if debugging
				the execution of the first few bytecodes"
		InterpreterLog isActive ifTrue:
			[InterpreterLog cr; nextPutAll: (self printExecutionState); endEntry].
		self dispatchOn: currentBytecode in: OpcodeTable.
		self assertIsLegalStackPointer: localSP.
		self assertIsLegalTempPointer: self temporaryPointer.
		(byteCount _ byteCount + 1)" == 175000 ifTrue: [InterpreterLog logToFile: 'LOG']".
	].
	self externalizeIPandSP.
