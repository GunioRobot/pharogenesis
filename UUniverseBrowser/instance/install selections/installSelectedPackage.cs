installSelectedPackage
	self anyPackageSelected ifFalse: [ ^self ].
	self installSet planToInstallPackage: self selectedPackage.
		
	self changed: #packageDescriptions.
	self changed: #rootCategoriesAndPackages.
