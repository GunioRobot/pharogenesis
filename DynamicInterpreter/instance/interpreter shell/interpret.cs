interpret
	"If newTranslatedMethod = nilObj then the interpreter is initialising: dispatch on opcodeIndex
	to store the address of the opcode in opcodeAddress, then return.
	If newTranslatedMethod ~= nilObj then the interpreter is starting execution: dispatch to the
	first instruction to begin execution."

	"Note: the current instruction is called currentBytecode for historical reasons (and is hard
	to change without breaking compatibility with the original Interpreter in the CCodeGenerator)."

	"Note: in the simulator this code is only executed for initialisation, never for execution."

	self inline: false.

	self interpreterInitializing ifFalse: [
		checkAssertions ifTrue: [self print: 'Warning: assertions are enabled'; cr].
		self internalizeIPandSP.
		self nextOp.		"dispatches to first instruction"
	].
	currentBytecode _ opcodeIndex.
	opcodeAddress _ 0.
	"the following loop is executed exactly once, but is needed to defeat dead code elimination
	in some C compilers"
	[opcodeAddress = 0] whileTrue: [self dispatchOn: currentBytecode in: OpcodeTable].
	^opcodeAddress