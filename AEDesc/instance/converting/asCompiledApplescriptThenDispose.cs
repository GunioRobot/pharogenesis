asCompiledApplescriptThenDispose

	| CAD |
	CAD _ self asCompiledApplescript.
	self dispose.
	^CAD