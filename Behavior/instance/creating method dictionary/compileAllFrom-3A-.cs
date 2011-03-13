compileAllFrom: oldClass
	"Compile all the methods in the receiver's method dictionary.
	This validates sourceCode and variable references and forces
	all methods to use the current bytecode set"

	self selectorsDo: [:sel | self recompile: sel from: oldClass]