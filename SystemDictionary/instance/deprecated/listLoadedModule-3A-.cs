listLoadedModule: index
	"Return the name of the n-th loaded module.
	This list is not sorted!"
	
	^self deprecated: 'Use SmalltalkImage current listLoadedModule:'
		block: [ SmalltalkImage current listLoadedModule: index ]