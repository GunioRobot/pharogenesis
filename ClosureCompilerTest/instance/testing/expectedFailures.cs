expectedFailures
	"The problem in the tests #testDebuggerTempAccess is that a compiler evaluate
	message is sent and this prevents the proper temp analysis of the closure compiler"
	
	^#(testDebuggerTempAccess testInjectIntoDecompilations testInjectIntoDecompiledDebugs)