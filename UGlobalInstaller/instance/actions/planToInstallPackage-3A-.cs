planToInstallPackage: initialPackage
	"plan to install a package plus its dependencies; refuses if any dependencies cannot be met"
	| newPackages |
	"find all packages needed to install this one"
	newPackages := self allPackagesNeededToInstall: initialPackage
						orIfImpossible: [ :missingDep |
								^self notify: 'could not find necessary package: ', missingDep ].
	
	selectedPackageVersions removeAllSuchThat: [ :p | p name = initialPackage name ].
	newPackages do: [ :p | selectedPackageVersions add: p ].