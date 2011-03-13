defaultModel
	
	Smalltalk at: #MCMultiPackageLoader ifPresent: [:cl | ^ cl new ].
	^MCPackageLoader new