subclass: nameOfClass  "Define root (superclass = nil) of a class hierarchy"
	instanceVariableNames: instVarNames
	classVariableNames: classVarNames
	poolDictionaries: poolDictnames
	category: category
	^(ClassBuilder new)
		superclass: self
		subclass: nameOfClass
		instanceVariableNames: instVarNames
		classVariableNames: classVarNames
		poolDictionaries: poolDictnames
		category: category
