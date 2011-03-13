popIntoTemporaryVariable: offset
	"Decompile."

	elements at: initIndex put: (decompiler tempAt: offset).
	initIndex _ initIndex - 1