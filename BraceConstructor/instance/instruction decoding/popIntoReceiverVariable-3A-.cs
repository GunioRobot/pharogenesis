popIntoReceiverVariable: offset
	"Decompile."

	elements at: initIndex put: (constructor codeInst: offset).
	initIndex _ initIndex - 1