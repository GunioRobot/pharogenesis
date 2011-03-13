updateFrom7048

	"self new updateFrom7048"
	self script79.
	
	self flushCaches.
	
	self cleanUpMethods.
	"recompile some methods"
	(nil systemNavigation allMethodsSelect: [:method |
	    (method methodClass methodDictionary includesIdentity: method) not])
	   do: [:cltr | cltr actualClass compileAll]
