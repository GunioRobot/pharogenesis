writeCompilerSourceFiles
	"Store into this image's directory the C sources files required to support the runtime compiler."
	"InterpreterSupportCode writeCompilerSourceFiles"

	self storeString: self primitiveTableDeclaration	onFileNamed: 'primitiveTable.decl'.
	self storeString: self primitiveTableDefinition		onFileNamed: 'primitiveTable.defn'.