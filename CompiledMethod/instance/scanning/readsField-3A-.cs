readsField: varIndex 
	"Answer whether the receiver loads the instance variable indexed by the argument."

	self allEmbeddedBlockMethods do: [:meth |
		| scanner catcher instr scan |
		scanner := meth scanner.
		catcher := MessageCatcher new.
		[scanner atEnd] whileFalse: [
			instr := scanner interpretNextInstructionFor: catcher.
			(instr selector = #send:super:numArgs: and: [instr argument = #privGetInstVar:]) ifTrue: [
				scan := scanner copy.
				scan pc: scan previousPc. scan pc: scan previousPc.
				instr := scan interpretNextInstructionFor: catcher.
				(instr selector = #pushConstant: and: [instr argument = varIndex])
					ifTrue: [^ true]
			].
		].
	].
	self isReturnField ifTrue: [^ self returnField + 1 = varIndex].
	varIndex <= 16 ifTrue: [^ self scanFor: varIndex - 1].
	varIndex <= 64 ifTrue: [^ self scanLongLoad: varIndex - 1].
	^ self scanVeryLongLoad: 64 offset: varIndex - 1