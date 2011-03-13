addPackage: aString constraint: aOneArgumentBlock
	"Add the package aString to the receiver, constraint the resulting versions further with aOneArgumentBlock."

	| reference |
	reference := GoferConstraintReference 
		name: aString repository: self repository.
	reference constraintBlock: aOneArgumentBlock.
	^ self add: reference