InstructionStream
	subclass: #Decompiler
	instanceVariableNames:
		'constructor method instVars tempVars constTable stack statements lastPc exit caseExits lastJumpPc lastReturnPc limit hasValue blockStackBase'
	classVariableNames: 'ArgumentFlag CascadeFlag CaseFlag IfNilFlag'
	poolDictionaries: ''
	category: 'Compiler-Kernel'