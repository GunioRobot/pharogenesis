new
	^ self == InterpreterSimulator
		ifTrue: [Smalltalk endianness == #big
				ifTrue: [InterpreterSimulatorMSB new]
				ifFalse: [InterpreterSimulatorLSB new]]
		ifFalse: [super new]