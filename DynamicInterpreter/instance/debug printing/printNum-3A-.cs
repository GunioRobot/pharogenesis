printNum: n
	"For testing in Smalltalk, this method should be overridden in a subclass."

	self cCode: 'fprintf(stderr, "%ld", (long) n)'.