hasPackageNamed: name
	^self packages anySatisfy: [ :p | p name = name ].
	