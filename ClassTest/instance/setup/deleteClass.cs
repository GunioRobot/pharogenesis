deleteClass
	| class |
	class := Smalltalk at: className ifAbsent: [^self].
	class removeFromChanges; removeFromSystemUnlogged 
	