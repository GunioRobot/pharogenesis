testEvalStrings
	| table |
	table := #('String new' 'Array with: 3 with: $a' '15+4').
	table := table evalStrings.

	self assert: table first isString.
	self assert: table first isEmpty.
	
	self assert: table second isArray.
	self assert: table second first = 3.
	self assert: table second second = $a.
	
	self assert: table third = 19.