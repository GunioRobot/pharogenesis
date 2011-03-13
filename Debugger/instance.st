CodeHolder
	subclass: #Debugger
	instanceVariableNames:
		'interruptedProcess interruptedController contextStack contextStackTop contextStackIndex contextStackList receiverInspector contextVariablesInspector externalInterrupt proceedValue selectingPC sourceMap tempNames savedCursor isolationHead failedProject errorWasInUIProcess labelString theMethodNode'
	classVariableNames: 'ContextStackKeystrokes ErrorRecursion'
	poolDictionaries: ''
	category: 'Tools-Debugger'