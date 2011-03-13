costumeNamed: aCostumeName
	"Answer a costume of the given name for the receiver.  If none found, create one"
	| found |
	found _ self costumeAt: aCostumeName ifAbsent: [nil].
	found ifNil:
		[found _ (Smalltalk at: aCostumeName asSymbol) new setNameTo: self externalName.
		self costumeDictionary at: aCostumeName put: found].
	^ found