isClosureCompiled
	"Return true if this method was compiled with the new closure compiler, Parser2 (compiled while Preference compileUseNewCompiler was true).  Return false if it was compiled with the old compiler."

	^ self header < 0