canMarkSelectionForInstallation
	^self anyPackageSelected and: [ 
		(self installSet isPackageVersionSelected: self selectedPackage) not and: [
			(self installSet isPackageVersionInstalled: self selectedPackage) not ]]