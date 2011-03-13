packagesNamed: name
	^self packages select: [ :p | p name = name ].
	