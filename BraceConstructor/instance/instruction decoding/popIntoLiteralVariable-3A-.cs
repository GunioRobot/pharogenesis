popIntoLiteralVariable: association
	"Decompile."

	elements at: initIndex put: (constructor codeAnyLitInd: association).
	initIndex _ initIndex - 1