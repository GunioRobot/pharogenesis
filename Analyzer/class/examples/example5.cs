example5
	"self example5"
	| classes | 
	classes := #(#ClassBuilder #ClassDescription #Class )
				collect: [:clsname | Smalltalk at: clsname].
	(Analyzer methodsIn: Behavior callingMethodsDefinedIn: classes) inspect