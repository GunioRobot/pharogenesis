tableLookup: table at: index
	"Note: Nasty coercion only necessary for the non-inlined version of this method in C. Duh? Oh well, here's the full story. The code below will definitely be inlined so everything that calls this method is fine. But... the translator doesn't quite prune this method so it generates a C function that tries to attempt an array access on an int - and most compilers don't like this. If you don't know what I'm talking about try to remove the C coercion and you'll see what happens when you try to compile a new VM..."
	self var: #table type: 'unsigned int *'.
	^table at: index
