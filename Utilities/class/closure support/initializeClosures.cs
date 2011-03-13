initializeClosures	"Utilities initializeClosures"
	"Eliminate the prototype BlockContext from the specialObjectsArray.  The VM doesn't use it. This paves the way for removing BlockCOntext altogether and merging ContextPart and MethodContext into e.g. Context."
	(Smalltalk specialObjectsArray at: 38) class == BlockContext 
		ifTrue:[Smalltalk specialObjectsArray at: 38 put: nil].
	"Remove unused class vars from CompiledMethod since we can't redefine its class definition directly. Add the new BlockClosure to the specialObjectsArray"
	(#(	BlockNodeCache MethodProperties SpecialConstants) 
			intersection: CompiledMethod classPool keys) 
				do:[:classVarName| CompiledMethod removeClassVarName: classVarName].
	Smalltalk recreateSpecialObjectsArray.
	"Recompile methods in ContextPart, superclasses and subclasses that access inst vars"
	ContextPart withAllSuperclasses, ContextPart allSubclasses asArray do:[:class|
		class instSize > 0 ifTrue:[
			class allInstVarNames do:[:ivn|
				(class whichSelectorsAccess: ivn) do:[:sel| class recompile: sel]]]]