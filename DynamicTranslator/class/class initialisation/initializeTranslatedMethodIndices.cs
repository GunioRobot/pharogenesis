initializeTranslatedMethodIndices			"DynamicTranslator initialize"

	MethodBiasIndex			_ 0.		"bias + 0-relative pre-inc tPC // 8 == Smalltalk 1-relative post-inc vPC"
	MethodSelectorIndex		_ 1.		"the method's selector"
	MethodArgCountIndex	_ 2.		"number of arguments"
	MethodMethodIndex		_ 3.		"original CompiledMethod"
	MethodClassIndex		_ 4.		"the expected class of the receiver"
	MethodPrimIndex		_ 5.		"primitive index of this method"
	MethodCycleIndex		_ 6.		"translation cycle to which this method belongs"
	MethodLinkageIndex		_ 7.		"additional data with which to check linked sends"

	"the following are currently unused by the Fake Inline Cache..."
	MethodCheckIndex		_ nil.		"prologue: check opcode"
	MethodCheckExtension	_ nil.		"check opcode extension word"
	MethodActivateIndex		_ nil.		"prologue: activation opcode"
	MethodActivateExtension	_ nil.		"activation opcode extension word"

	MethodOpcodeStart		_ 8.		"first opcode in translated method"

	"Notes:	  -	the original selector is not available in relink, so is stored in the header during translation.
			  -	argumentCount is needed even in linked sends, in order to pop the stack.  Sigh."