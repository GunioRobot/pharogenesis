duplicatedPlayerForCostume: aCostume
	"Answer a new Player that starts out life with the same set of methods as the receiver has.  You'll need to get its costume set up properly."

	| anInstance |
	anInstance _ self class officialClass instanceOfUniqueClassWithInstVarString: self class instanceVariablesString andClassInstVarString: self class class instanceVariablesString.
	anInstance costume: aCostume.
	anInstance copyStateFrom: self.
	anInstance class copyMethodDictionaryFrom: self class.
	^ anInstance