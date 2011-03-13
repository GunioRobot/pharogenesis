whichSelectorsAccess: instVarName 
	"Answer a set of selectors whose methods access the argument, 
	instVarName, as a named instance variable."

	| instVarIndex |
	instVarIndex _ self allInstVarNames indexOf: instVarName ifAbsent: [^IdentitySet new].
	^ self methodDict keys select: 
		[:sel | 
		((self methodDict at: sel)
			readsField: instVarIndex)
			or: [(self methodDict at: sel) writesField: instVarIndex]]

	"Point whichSelectorsAccess: 'x'."