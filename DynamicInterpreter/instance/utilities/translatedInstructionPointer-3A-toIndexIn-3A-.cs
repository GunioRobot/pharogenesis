translatedInstructionPointer: ip toIndexIn: tMeth
	self inline: true.
	^self integerObjectOf:
		(((ip - tMeth - (MethodOpcodeStart * 4)) // 8) + (self translatedMethodBias: tMeth))