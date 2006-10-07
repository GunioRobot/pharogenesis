deleteRenamedClass
	| cl |
	cl := Smalltalk at: renamedName ifAbsent: [^self].
	cl removeFromChanges; removeFromSystemUnlogged 
	