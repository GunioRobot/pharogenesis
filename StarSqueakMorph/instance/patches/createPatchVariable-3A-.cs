createPatchVariable: patchVarName
	"Create a patch variable of the given name. It is initialized to a value of zero for every patch."

	patchVariables
		at: patchVarName
		put: (Bitmap new: (dimensions x * dimensions y) withAll: 0).
