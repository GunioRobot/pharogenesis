hasMorphic
	"Answer whether the Morphic classes are available in the system (they may have been stripped, such as by a call to Smalltalk removeMorphic"

	^ ((Smalltalk at: #Morph ifAbsent: [nil]) isKindOf: Class)