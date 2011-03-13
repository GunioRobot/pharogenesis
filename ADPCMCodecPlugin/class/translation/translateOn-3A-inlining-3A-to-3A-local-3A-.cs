translateOn: cg inlining: inlineFlag to: fullName local: localFlag
	"ADPCMCodecPlugin translateLocally"
	| code |
	cg addClass: InterpreterPlugin.
	InterpreterPlugin declareCVarsIn: cg.
	cg addMethodsForPrimitives: ADPCMCodec translatedPrimitives.
	"now remove a few which will be inlined but not pruned"
	cg pruneMethods: #(indexForDeltaFrom:to: nextBits: nextBits:put:).
	code _ cg generateCodeStringForPrimitives.
	self storeString: code onFileNamed: fullName.