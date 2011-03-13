addString: literalOrVarName
	| sMorph |
	"Create and return an UpdatingStringMorph containing the value.  Use an UpdatingStringMorph, so it can inform its owner when it has been edited."

	sMorph _ UpdatingStringMorph contents: literalOrVarName.
	sMorph target: self; putSelector: #acceptIgnoring:; useStringFormat.
	"keep the getSelector being nil"
	^ sMorph