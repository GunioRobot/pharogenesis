selectPackageOrCategory: packageOrCategory
	selectedPackage := 
		packageOrCategory isUPackage
			ifTrue: [ packageOrCategory ]
			ifFalse: [ nil ].
	self changed: #selectedPackage.
	self changed: #selectedPackageDescription.
	self changed: #canMarkSelectionForInstallation.

	