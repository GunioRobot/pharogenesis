copyForValidation
	"Make a copy of the receiver (a class) but do not install the created class 
	as a new class in the system. This is used for creating a new version of 
	the receiver in which the installation is deferred until all changes are 
	successfully completed."
	| newClass |
	newClass _ self class copy new
		superclass: superclass
		methodDict: methodDict copy
		format: format
		name: name
		organization: organization
		instVarNames: instanceVariables copy
		classPool: classPool
		sharedPools: sharedPools.
	Class instSize+1 to: self class instSize do:
		[:offset | newClass instVarAt: offset put: (self instVarAt: offset)].
	^ newClass