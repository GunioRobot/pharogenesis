removePackageNamed: packageName withVersion: version
	| packagesToRemove |
	packagesToRemove _ self packages select: [ :p | p name = packageName and: [ p version = version ] ].
	packagesToRemove do: [ :p | self removePackage: p ].
	