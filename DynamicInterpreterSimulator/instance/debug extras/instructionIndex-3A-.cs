instructionIndex: ip

	^self integerValueOf:
		(self translatedInstructionPointer: ip toIndexIn: (self translatedMethod))