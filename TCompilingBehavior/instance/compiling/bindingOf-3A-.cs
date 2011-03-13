bindingOf: varName
	
	"Answer the binding of some variable resolved in the scope of the receiver"
	| aSymbol binding |
	aSymbol _ varName asSymbol.

	"Look in declared environment."
	binding _ self environment bindingOf: aSymbol.
	^binding