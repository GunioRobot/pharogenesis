listBuiltinModule: index
	"Return the name of the n-th builtin module.
	This list is not sorted!"
	
	^self deprecated: 'Use SmalltalkImage current listBuiltinModule:'
		block: [SmalltalkImage current listBuiltinModule: index]