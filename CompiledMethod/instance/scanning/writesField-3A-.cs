writesField: field 
	"Answer whether the receiver stores into the instance variable indexed by the argument."

	self allEmbeddedBlockMethods do: [:meth |
		| scanner catcher instr scan |
		scanner := meth scanner.
		catcher := MessageCatcher new.
		[scanner atEnd] whileFalse: [
			instr := scanner interpretNextInstructionFor: catcher.
			(instr selector = #send:super:numArgs: and: [instr argument = #privStoreIn:instVar:]) ifTrue: [
				scan := scanner copy.
				scan pc: scan previousPc. scan pc: scan previousPc.
				instr := scan interpretNextInstructionFor: catcher.
				(instr selector = #pushConstant: and: [instr argument = field])
					ifTrue: [^ true]
			].
		].
	].
	self isQuick ifTrue: [^ false].
	field <= 8 ifTrue:
		[^ (self scanFor: 96 + field - 1) or: [self scanLongStore: field - 1]].
	field <= 64 ifTrue:
		[^ self scanLongStore: field - 1].
	^ self scanVeryLongStore: 160 offset: field - 1