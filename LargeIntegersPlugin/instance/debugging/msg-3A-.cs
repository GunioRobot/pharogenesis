msg: s 
	self var: #s declareC: 'char *s'.
	self cCode: 'fprintf(stderr, "\n%s: %s", moduleName, s)' inSmalltalk: [Transcript cr; show: self class moduleName , ': ' , s; endEntry]