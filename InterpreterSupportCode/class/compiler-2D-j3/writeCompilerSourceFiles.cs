writeCompilerSourceFiles
	"Store into this image's directory the C sources files required to support the runtime compiler."
	"InterpreterSupportCode writeCompilerSourceFiles"

	| tricky |
	tricky _ self trickyPrimitiveList.
	self storeString: (self primitiveHeaderString: tricky)			onFileNamed: 'primitives.h'.
	self storeString: (self primitiveImplementationString: tricky)	onFileNamed: 'primitives.cc'.