set: patchVarName to: newValue
	"Set the value of the given patch variable for this patch to the given value."

	| patchVar |
	patchVar := world patchVariable: patchVarName ifAbsent: [^ self].
	patchVar at: (y * world dimensions x) + x + 1 put: newValue.
