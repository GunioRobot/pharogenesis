addInstanceVarNamed: aName withValue: aValue

	self basicAddInstanceVarNamed: aName withValue: aValue.
	"turtles _ kedamaWorld turtlesOf: self."
	turtles addInstanceVarVectorNamed: aName withValue: aValue.
