rawSetPreference: prefSymbol toValue: aBoolean
	"Set the given preference to the given value, without further ado"
	FlagDictionary at: prefSymbol put: aBoolean
