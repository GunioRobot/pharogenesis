method8: arg

	| a |
	self returnTypeC: 'float'.
	self var: #a    declareC: 'float a = 0'.
	self var: #arg declareC: 'float arg'.
	self cCode: 'a = arg * 3.14159'.
	^a