deletePreference: preferenceNameSymbol

	FlagDictionary removeKey: preferenceNameSymbol ifAbsent: [^ self].
	self resetCategoryInfo
