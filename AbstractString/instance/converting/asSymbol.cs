asSymbol
	"Answer the unique Symbol whose characters are the characters of the 
	string."

	^ self class correspondingSymbolClass intern: self.
