print: s
	"For testing in Smalltalk, this method should be overridden in a subclass."

	self var: #s declareC: 'char *s'.
	self cCode: 'fprintf(stderr, "%s", s)'.