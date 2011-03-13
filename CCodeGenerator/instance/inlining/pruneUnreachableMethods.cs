pruneUnreachableMethods
	"Remove any methods that are not reachable. Retain methods needed by the BitBlt operation table, primitives, plug-ins, or interpreter support code."
 
	| retain |
	"Build a set of selectors for methods that should be output even though they have no apparent callers. Some of these are stored in tables for indirect lookup, some are called by the C support code or by primitives."
	retain _ BitBltSimulation opTable asSet.
	#(checkedLongAt: fullDisplayUpdate interpret printCallStack
	   readImageFromFile:HeapSize:StartingAt: success:
		"Windows needs the following two for startup and debug"
	   readableFormat: getCurrentBytecode
		"Jitter reuses all of these"
	   allocateChunk: characterForAscii:
	   findClassOfMethod:forReceiver: findSelectorOfMethod:forReceiver:
	   firstAccessibleObject loadInitialContext noteAsRoot:headerLoc:
	   nullCompilerHook
	   primitiveFloatAdd primitiveFloatDivide primitiveFloatMultiply
	   primitiveFloatSubtract primitiveFlushExternalPrimitives
	   setCompilerInitialized: splObj:)
			do: [:sel | retain add: sel].
	InterpreterProxy organization categories do: [:cat |
		((cat ~= 'initialize') and: [cat ~= 'private']) ifTrue: [
			retain addAll: (InterpreterProxy organization listAtCategoryNamed: cat)]].

	"Remove all the unreachable methods that aren't retained for the reasons above."
	self unreachableMethods do: [:sel |
		(retain includes: sel) ifFalse: [
			methods removeKey: sel ifAbsent: []]].
