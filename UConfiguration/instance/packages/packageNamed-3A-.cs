packageNamed: name
	^self installedPackages detect: [ :p | p name = name ]