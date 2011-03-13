CodeHolder
	subclass: #Debugger
	instanceVariableNames:
		'interruptedProcess interruptedController contextStack contextStackTop contextStackIndex contextStackList receiverInspector contextVariablesInspector externalInterrupt proceedValue selectingPC sourceMap tempNames savedCursor isolationHead failedProject errorWasInUIProcess '
	classVariableNames: 'ContextStackKeystrokes ErrorRecursion '
	poolDictionaries: ''
	category: 'Tools-Debugger'