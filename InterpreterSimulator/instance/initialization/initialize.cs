initialize
	"Initialize the InterpreterSimulator when running the interpreter inside
	Smalltalk. The primary responsibility of this method is to allocate
	Smalltalk Arrays for variables that will be declared as statically-allocated
	global arrays in the translated code."

	"initialize class variables"
	ObjectMemory initialize.
	Interpreter initialize.

	methodCache _ Array new: MethodCacheSize.
	rootTable _ Array new: RootTableSize.
	remapBuffer _ Array new: RemapBufferSize.
	semaphoresToSignal _ Array new: SemaphoresToSignalSize.

	"initialize InterpreterSimulator variables used for debugging"
	byteCount _ 0.
	sendCount _ 0.
	traceOn _ true.
	myBitBlt _ BitBltSimulator new setInterpreter: self.
	displayForm _ nil.  "displayForm is created in response to primitiveBeDisplay"
	filesOpen _ OrderedCollection new.
