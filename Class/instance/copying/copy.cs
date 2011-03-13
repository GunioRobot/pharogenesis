copy 
	| newClass |
	newClass := self class copy new
		superclass: superclass
		methodDict: self methodDict copy
		format: format
		name: name
		organization: self organization copy
		instVarNames: instanceVariables copy
		classPool: classPool copy
		sharedPools: sharedPools.
	Class instSize+1 to: self class instSize do:
		[:offset | newClass instVarAt: offset put: (self instVarAt: offset)].
	^ newClass