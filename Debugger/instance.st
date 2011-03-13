CodeHolder
	subclass: #Debugger
	instanceVariableNames:
		'interruptedProcess interruptedController contextStack contextStackTop contextStackIndex contextStackList receiverInspector contextVariablesInspector externalInterrupt proceedValue selectingPC debuggerMap savedCursor isolationHead failedProject errorWasInUIProcess labelString'
	classVariableNames: 'ContextStackKeystrokes ErrorRecursion'
	poolDictionaries: ''
	category: 'Tools-Debugger'