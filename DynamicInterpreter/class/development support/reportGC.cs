reportGC		"CacheInterpreter reportGC"
	"Report all methods in the interpreter hierarchy that might provoke a GC, giving for each a list
	of the methods that it calls around which temporaries and arguments must be made remappable.
	Useful for finding those obscure remapping errors in the VM: save the result, print it out, and
	pin it to your wall!
	(An alternative approach is to munge the ObjectMemory into provoking a fullGC after every
	allocation, then generate a VM with checks enabled -- but the result runs [in fully optimised
	and gnuified C] *slower* than the InterpreterSimulator!! ;-)"

	| list selectors break theClass theSelector dangerous result |
	list _ self makeGCList.
	selectors _ list at: 1.
	result _ String streamContents: [:report |
		(list at: 2) do: [:classAndSelector |	
			break _ classAndSelector indexOf: $ .
			theClass _ Smalltalk at: (classAndSelector copyFrom: 1 to: break - 1) asSymbol.
			theSelector _ (classAndSelector copyFrom: break + 1 to: classAndSelector size) asSymbol.
			dangerous _ (theClass compiledMethodAt: theSelector) literals select: [:lit | selectors includes: lit].
			dangerous isEmpty ifTrue: [self error: 'huh?'].
			report nextPutAll: classAndSelector , ' --'.
			dangerous do: [:dangerSelector | report space; nextPutAll: dangerSelector].
			report cr]].
	StringHolderView open: (StringHolder new contents: result) label: 'GC-unsafe sends'