noteInterestOf: client inAll: classes 
	| newlyInteresting |
	LocalSends current noteInterestOf: self
		inAll: (classes gather: [:cl | cl withAllSuperclasses]).
	ProvidedSelectors current noteInterestOf: self
		inAll: (classes gather: [:cl | cl withAllSuperclasses]).
	newlyInteresting := classes copyWithoutAll: self classesOfInterest.
	super noteInterestOf: client inAll: classes.
	newlyInteresting do: [:cl | self newlyInteresting: cl]