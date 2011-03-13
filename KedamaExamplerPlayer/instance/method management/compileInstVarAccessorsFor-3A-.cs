compileInstVarAccessorsFor: varName

	self basicCompileInstVarAccessorsFor: varName.
	"turtles _ kedamaWorld turtlesOf: self."
	turtles compileVectorInstVarAccessorsFor: varName.
	sequentialStub compileScalarInstVarAccessorsFor: varName.
