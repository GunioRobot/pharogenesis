comparativeBenchmarks
	"InterpreterSupportCode comparativeBenchmarks"

	Smalltalk compilerDisable.
	self compilerBenchmarks.
	Transcript show: '  interpreted'.
	Smalltalk compilerEnable.
	self compilerBenchmarks.
	Transcript show: '  compiled'.