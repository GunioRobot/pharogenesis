initialize
	"Initialize the InterpreterSimulator when running the interpreter inside
	Smalltalk. The primary responsibility of this method is to allocate
	Smalltalk Arrays for variables that will be declared as statically-allocated
	global arrays in the translated code."

	"initialize class variables"
	ObjectMemory initialize.
	Interpreter initialize.

	methodCache _ Array new: MethodCacheSize.
	atCache _ Array new: AtCacheTotalSize.
	rootTable _ Array new: RootTableSize.
	remapBuffer _ Array new: RemapBufferSize.
	semaphoresUseBufferA _ true.
	semaphoresToSignalA _ Array new: SemaphoresToSignalSize.
	semaphoresToSignalB _ Array new: SemaphoresToSignalSize.
	externalPrimitiveTable _ CArrayAccessor on: (Array new: MaxExternalPrimitiveTableSize size).

	obsoleteNamedPrimitiveTable _ 
		CArrayAccessor on: self class obsoleteNamedPrimitiveTable.
	obsoleteIndexedPrimitiveTable _ CArrayAccessor on: 
		(self class obsoleteIndexedPrimitiveTable collect:[:spec| 
			CArrayAccessor on:
				(spec ifNil:[Array new: 3] 
					  ifNotNil:[Array with: spec first with: spec second with: nil])]).
	pluginList _ #().
	mappedPluginEntries _ #().

	"initialize InterpreterSimulator variables used for debugging"
	byteCount _ 0.
	sendCount _ 0.
	traceOn _ true.
	myBitBlt _ BitBltSimulator new setInterpreter: self.
	displayForm _ nil.  "displayForm is created in response to primitiveBeDisplay"
	filesOpen _ OrderedCollection new.
