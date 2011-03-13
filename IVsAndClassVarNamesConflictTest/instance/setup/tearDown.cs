tearDown
	| cl |
	super tearDown.
	cl := Smalltalk at: className ifAbsent: [^self].
	cl removeFromChanges; removeFromSystemUnlogged 
	