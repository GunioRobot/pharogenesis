fetchInstruction
	"This method uses the preIncrement builtin function which has no Smalltalk equivalent. Thus, it must be overridden in the simulator."
	| insn |
	self inline: true.
	insn _ self longAt: (localIP _ localIP + 4).
			"localIP _ localIP + 4."		"skip empty extension slot"
"Transcript cr; show: '### ' , (self integerValueOf: insn) hex."
	^self integerValueOf: insn