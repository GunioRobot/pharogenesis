translateInDirectory: directory doInlining: inlineFlag
"handle a special case code string rather than generated code. 
NB sqOldSoundsPrims IS NOT FULLY INTEGRATED - it still isn't included in the exports list"
	| cg |
	self initialize.

	cg _ self buildCodeGeneratorUpTo: InterpreterPlugin.

	cg addMethodsForPrimitives: AbstractSound translatedPrimitives.
	self storeString: cg generateCodeStringForPrimitives onFileNamed: (directory fullNameFor: self moduleName, '.c').
	"What we need here is some way to derive the prim names from sqOldSoundPrims - or dump it entirely. Perhaps add this class (without then generating the file again) using fake entry points like SurfacePlugin does"

	^cg exportedPrimitiveNames asArray
