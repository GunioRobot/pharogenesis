patchVariable: patchVarName ifAbsent: aBlock
	"Answer the patch variable array of the given name. If no such patch variables exists, answer the result of evaluating the given block."

	^ patchVariables at: patchVarName ifAbsent: aBlock
