addClassVarsFor: aClass
	"Add the class variables for the given class (and its superclasses) to the code base as constants."

	| allClasses |
	allClasses _ aClass allSuperclasses asOrderedCollection.
	allClasses add: aClass.
	allClasses do: [:c |
		c classPool associationsDo:
			[:assoc | constants at: assoc key put: (TConstantNode new setValue: assoc value)]].
