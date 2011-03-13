macroBenchmark2  "Smalltalk macroBenchmark2"
	"Copied from Interpreter class>>translate:doInlining:forBrowserPlugin:"
	| doInlining cg fileName inlineFlag pluginFlag |
	fileName _ 'benchmark2.out'.
	inlineFlag _ true.
	pluginFlag _ false.
	doInlining _ inlineFlag.
	pluginFlag ifTrue: [doInlining _ true].  "must inline when generating browser plugin"
	Interpreter initialize.
	ObjectMemory initialize.
	cg _ CCodeGenerator new initialize.
	cg addClass: Interpreter.
	cg addClass: ObjectMemory.
	Interpreter declareCVarsIn: cg.
	ObjectMemory declareCVarsIn: cg.
	FileDirectory default deleteFileNamed: fileName.
	cg storeCodeOnFile: fileName doInlining: doInlining.
	FileDirectory default deleteFileNamed: fileName.

