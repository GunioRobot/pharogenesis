initialize

	"MultiSymbol initialize"

	MultiSymbol rehash.
	OneCharacterMultiSymbols _ nil.
	OneCharacterMultiSymbols _ (1 to: 256) collect: [ :i | (i - 1) asCharacter asSymbol].
	Smalltalk addToShutDownList: self.
