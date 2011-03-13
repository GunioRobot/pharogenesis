printClass: class 
	"Create a file whose name is the argument followed by '.bytes'. Store on 
	the file the symbolic form of the compiled methods of the class."
	| file |
	file _ FileStream newFileNamed: class name , '.bytes'.
	class selectors do: 
		[:sel | 
		file cr; nextPutAll: sel; cr.
		(self on: (class compiledMethodAt: sel)) printInstructionsOn: file].
	file close
	"InstructionPrinter printClass: Parser."
