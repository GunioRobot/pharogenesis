isSystemScriptName: aName
	"Answer whether the given name is a reserved script name"

	^ ReservedScriptNames includes: aName asSymbol