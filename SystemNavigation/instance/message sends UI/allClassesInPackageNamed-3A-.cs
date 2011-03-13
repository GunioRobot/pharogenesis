allClassesInPackageNamed: packageName
	| classes |
	classes := (SystemOrganization classesInCategory: packageName) asSet.
	(SystemOrganization categoriesMatching: packageName, '-*') do: [:category| 
		classes addAll: (SystemOrganization classesInCategory: category)].
	^classes asArray