addMethodRoot: tMeth

	"Record that the given translated method in the old object area may point to an object in the young area."

	self beRootIfOld: tMeth