newestPackageNamed: name
	| potentials sorted |
	potentials _ self packagesNamed: name.
	sorted _ potentials asSortedCollection: [ :p1 :p2 | p1 version < p2 version ].
	^sorted last