initialize
	packageInfo := Smalltalk at: #PackageInfo ifAbsent:[nil].
	packageInfo ifNil:[self error: 'PackageInfo is required'].