logTo: fileName

	InterpreterLog logToFile: fileName.
	byteCount _ 0.
	self internalizeIPandSP.
	[true] whileTrue: [
		currentBytecode _ self fetchInstruction.
		"InterpreterLog>>endEntry is called at every context change"
		InterpreterLog isActive ifTrue:
			[InterpreterLog cr; nextPutAll: (self printExecutionState)].
		self dispatchOn: currentBytecode in: OpcodeTable.
		(byteCount _ byteCount + 1) "= -40900 ifTrue: [InterpreterLog logToFile: 'LOG']".
	].
	self externalizeIPandSP.
