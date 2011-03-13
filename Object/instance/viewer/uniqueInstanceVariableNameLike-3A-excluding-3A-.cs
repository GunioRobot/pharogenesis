uniqueInstanceVariableNameLike: aString excluding: takenNames
	"Answer a nice instance-variable name to be added to the receiver which resembles aString, making sure it does not coincide with any element in takenNames"

	| okBase uniqueName usedNames |
	usedNames _ self class allInstVarNamesEverywhere.
	usedNames removeAllFoundIn: self class instVarNames.
	usedNames addAll: takenNames.
	okBase _ Scanner wellFormedInstanceVariableNameFrom: aString.

	uniqueName _ Utilities keyLike: okBase satisfying: 
		[:aKey | (usedNames includes: aKey) not].

	^ uniqueName