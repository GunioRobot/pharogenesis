profileSends: nBytecodes
	"(DynamicInterpreterSimulatorLSB new openOn: 'devel-1.3.image') profileSends: 5000"
	Transcript clear.
	InterpreterLog close.
	byteCount _ 0.
	Transcript show: (Time millisecondsToRun: [MessageTally tallySendsTo: self
		inBlock:
				[self internalizeIPandSP.
				[byteCount < nBytecodes] whileTrue:
					[currentBytecode _ self fetchInstruction.
					self dispatchOn: currentBytecode in: OpcodeTable.
					byteCount _ byteCount + 1].
				self externalizeIPandSP]
		showTree: true]) printString.