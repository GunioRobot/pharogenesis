checkGC		"CacheInterpreter checkGC"
	"Browse all methods in the interpreter hierarchy that might provoke a GC.  Useful for checking
	if oops are being made remappable in all the dangerous places."

	| list |
	list _ self makeGCList.
	"Possible optimisation: remove any entries for methods that have no temporaries or arguments?"
	Smalltalk
		browseMessageList: (list at: 2)
		name: 'methods susceptible to garbage collection'