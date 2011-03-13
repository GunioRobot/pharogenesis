match: keys fields: docks
	| longString |
	"see if each key occurs in my corresponding text instance."

	keys withIndexDo: [:kk :ind |
		kk ifNotNil: [
			longString := (self perform: (docks at: ind) playerGetSelector) string.
			kk do: [:aKey |
				((longString findString: aKey startingAt: 1 caseSensitive: false) > 0)
					ifFalse: [^ false]]]]. 	"all keys must match"
	^ true