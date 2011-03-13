InstructionStream
	subclass: #Decompiler
	instanceVariableNames:
		'constructor method instVars tempVars constTable stack statements lastPc exit lastJumpPc lastReturnPc limit hasValue blockStackBase '
	classVariableNames: 'ArgumentFlag CascadeFlag CaseFlag '
	poolDictionaries: ''
	category: 'System-Compiler'