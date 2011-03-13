testShouldKnowPackageName
	| package |
	package := GoferPackageReference name: 'Gofer'.
	self assert: package packageName = 'Gofer'.
	
	package := GoferConstraintReference name: 'Gofer'.
	self assert: package packageName = 'Gofer'.
	
	package := GoferVersionReference name: 'Gofer-lr.34'.
	self assert: package packageName = 'Gofer'