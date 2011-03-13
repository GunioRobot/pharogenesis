removeAccessorsFor: varName
	"Remove the instance-variable accessor methods associated with varName"

	| nameString |
	nameString _ varName asString capitalized.
	self removeSelectorUnlogged: ('get', nameString) asSymbol.
	self removeSelectorUnlogged: ('set', nameString, ':') asSymbol