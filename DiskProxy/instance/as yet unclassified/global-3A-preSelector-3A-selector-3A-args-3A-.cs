global: globalNameSymbol preSelector: aSelector selector: selectorSymbol args: argArray
	"Initialize self as a DiskProxy constructor with the given
	globalNameSymbol, selectorSymbol, and argument Array.
	I will internalize by looking up the global object name in the
	SystemDictionary (Smalltalk) and sending it this message with
	these arguments."

	globalObjectName _ globalNameSymbol asSymbol.
	preSelector _ aSelector asSymbol.
	constructorSelector _ selectorSymbol asSymbol.
	constructorArgs _ argArray.