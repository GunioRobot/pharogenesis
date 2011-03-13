get: patchVarName
	"Answer the value of the given patch variable for this patch."

	| patchVar |
	patchVar := world patchVariable: patchVarName ifAbsent: [^ 0].
	^ patchVar at: (y * world dimensions x) + x + 1
