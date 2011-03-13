includesPackageSpec: packageSpec
	^self installedPackages anySatisfy: [ :p | p packageSpec = packageSpec ]