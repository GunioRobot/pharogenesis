mapInterpreterOops
	"Map all oops in the interpreter's state to their new values 
	during garbage collection or a become: operation."
	"Assume: All traced variables contain valid oops."
	| oop |
	nilObj _ self remap: nilObj.
	falseObj _ self remap: falseObj.
	trueObj _ self remap: trueObj.
	specialObjectsOop _ self remap: specialObjectsOop.
	compilerInitialized
		ifFalse: [stackPointer _ stackPointer - activeContext. "*rel to active"
			activeContext _ self remap: activeContext.
			stackPointer _ stackPointer + activeContext. "*rel to active"
			theHomeContext _ self remap: theHomeContext].
	instructionPointer _ instructionPointer - method. "*rel to method"
	method _ self remap: method.
	instructionPointer _ instructionPointer + method. "*rel to method"
	receiver _ self remap: receiver.
	messageSelector _ self remap: messageSelector.
	newMethod _ self remap: newMethod.
	methodClass _ self remap: methodClass.
	lkupClass _ self remap: lkupClass.
	receiverClass _ self remap: receiverClass.
	1 to: remapBufferCount do: [:i | 
			oop _ remapBuffer at: i.
			(self isIntegerObject: oop)
				ifFalse: [remapBuffer at: i put: (self remap: oop)]]