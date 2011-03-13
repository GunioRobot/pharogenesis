recompileChanges
	"Compile all the methods that are in the changes file.
	This validates sourceCode and variable references and forces
	methods to use the current bytecode set"

	self selectorsDo:
		[:sel | (self compiledMethodAt: sel) fileIndex > 1 ifTrue:
			[self recompile: sel from: self]]