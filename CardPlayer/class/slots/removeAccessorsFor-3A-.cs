removeAccessorsFor: varName
	"Remove the instance-variable accessor methods associated with varName"

	| nameString |
	nameString _ varName asString capitalized.
	self removeSelectorSilently: ('get', nameString) asSymbol.
	self removeSelectorSilently: ('set', nameString, ':') asSymbol