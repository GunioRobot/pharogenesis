= aPackageSpec
	^(aPackageSpec isKindOf: UPackageSpec) and: [
		aPackageSpec name = name and: [
			aPackageSpec version = version ]]