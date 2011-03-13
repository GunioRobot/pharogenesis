arg1: a arg2: b
	"CCodeGenerator new initialize addClass: TestCClass1"

	| i j k |
	self var: #i declareC: 'char *i'.
	i _ 'abc'.
	j _ 2.
	k _ 3.