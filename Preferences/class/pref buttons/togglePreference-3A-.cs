togglePreference: prefSymbol
	| curr |
	curr _ (FlagDictionary at: prefSymbol ifAbsent: [^ self error: 'unknown pref: ', prefSymbol printString]).
	self setPreference: prefSymbol toValue: (curr == true) not

