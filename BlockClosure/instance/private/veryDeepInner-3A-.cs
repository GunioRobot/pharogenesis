veryDeepInner: deepCopier
	"Do not copy my method (which can be shared because CompiledMethod2 are basically treated as immutables) or my home context (MethodContexts are treated as immutables too)"

	super veryDeepInner: deepCopier.
	method _ method.
	environment _ environment.
