subclass: nameOfClass  "Define root (superclass = nil) of a class hierarchy"
	instanceVariableNames: instVarNames
	classVariableNames: classVarNames
	poolDictionaries: poolDictnames
	category: category
	| newClass |
	newClass _ Object subclass: nameOfClass  "First, define as a normal class"
	instanceVariableNames: instVarNames
	classVariableNames: classVarNames
	poolDictionaries: poolDictnames
	category: category.

	Object removeSubclass: newClass.   "Then remove it from the old hierarchy"
	newClass superclass: nil.
	^ newClass