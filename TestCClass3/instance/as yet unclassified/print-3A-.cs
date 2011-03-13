print: s

	self var: #s declareC: 'char *s'.
	self cCode: 'printf("%s", s)'.