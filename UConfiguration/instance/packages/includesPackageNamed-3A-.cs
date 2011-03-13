includesPackageNamed: name
	^self installedPackages anySatisfy: [ :p | p name = name ]