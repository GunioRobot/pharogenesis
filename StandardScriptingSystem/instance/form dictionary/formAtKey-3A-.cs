formAtKey: aKey
	"ScriptingSystem saveForm: (TileMorph downPicture) atKey: 'downArrow'"
	^ FormDictionary at: aKey asSymbol ifAbsent: [nil]