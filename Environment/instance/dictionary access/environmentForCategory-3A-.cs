environmentForCategory: catString
	"Smalltalk environmentForCategory:'Morphic'"
	"Accepts a category name which may be a symbol or a string,
	and which may have trailing parts of the form '-zort'.
	Returns the environment object of that name."

	| catName envt |
	catName _ (catString copyUpTo: $-) asSymbol.
	(Smalltalk kernelCategories includes: catName)
		ifTrue: [^ Smalltalk].
	envt _ Smalltalk at: catName ifAbsent:
		[(self confirm: 'Use of the category name
' , catName , '
implies the need to create a new system category.
Is this what you wish to do?')
			ifFalse: [self error: 'dismiss me'].
		Smalltalk makeSubEnvironmentNamed: catName].
	(envt isKindOf: Environment) ifFalse:
		[self error: catName , ' cannot be used as an environment name.'].
	^ envt