initialize

	"Symbol initialize"

	Symbol rehash.
	OneCharacterSymbols _ nil.
	OneCharacterSymbols _ (1 to: 256) collect: [ :i | (i - 1) asCharacter asSymbol].
	Smalltalk addToShutDownList: self.
