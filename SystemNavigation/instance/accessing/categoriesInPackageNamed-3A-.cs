categoriesInPackageNamed: packageName
	^(SystemOrganization categoriesMatching: packageName), (SystemOrganization categoriesMatching: packageName, '*')