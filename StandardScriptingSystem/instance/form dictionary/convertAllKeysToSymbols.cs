convertAllKeysToSymbols
	| newDict |
	"ScriptingSystem convertAllKeysToSymbols"
	newDict _ IdentityDictionary new.
	FormDictionary associationsDo:
		[:assoc |
			newDict at: assoc key asSymbol put: assoc value].
	FormDictionary _ newDict

"(FormDictionary keys asArray collect: [:k | k class name]) asBag sortedElements"