recompileAll
	"Recompile all classes, starting with given name."

	Smalltalk forgetDoIts.
	Smalltalk allClassesAndTraits do: [:classOrTrait | classOrTrait compileAll] displayingProgress: 'Recompiling all classes and traits'. 


