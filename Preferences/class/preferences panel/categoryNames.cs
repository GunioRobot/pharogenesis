categoryNames
	| aSet |
	aSet := Set new.
	DictionaryOfPreferences do: [:aPreference |
		aSet addAll: (aPreference categoryList collect: [:aCategory | aCategory asSymbol])].
	^aSet.