translatedInstructionIndex: ip toPointerIn: tMeth
	self inline: true.
	^(((self integerValueOf: ip) - (self translatedMethodBias: tMeth)) * 8)
		+ (4 * MethodOpcodeStart) + tMeth