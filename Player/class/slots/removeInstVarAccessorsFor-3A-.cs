removeInstVarAccessorsFor: varName
	| nameString |

	nameString _ varName asString capitalized.
	self removeSelector: ('get', nameString) asSymbol.
	self removeSelector: ('set', nameString, ':') asSymbol