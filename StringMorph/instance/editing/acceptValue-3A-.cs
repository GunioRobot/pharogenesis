acceptValue: aValue
	| val |
	self contents: (val := aValue asString).
	^ val