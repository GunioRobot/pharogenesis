allPackagesNeededToInstall: initialPackage  orIfImpossible: errorBlock
	"find all packages needed to installed initialPackage; if it is impossible to accomplish, invoke errorBlock with the name of the missing package"
	| newPackages packagesToConsider |
	newPackages := Set new.
	packagesToConsider := OrderedCollection with: initialPackage.
	[ packagesToConsider isEmpty ]
		whileFalse: [| package |
			package := packagesToConsider removeFirst.
			(newPackages includes: package) ifFalse: [
			newPackages add: package.
			package depends do: [ :depName |
				((configuration includesPackageNamed: depName) not and: [ selectedPackageVersions noneSatisfy: [ :p | p name = depName  ] ])
				ifTrue: [
					"the dependency is needed but is not installed or planned to be installed"
					(universe hasPackageNamed: depName) ifTrue: [
						"in principle, one could additionally consider trying a different package than the newest..."
						packagesToConsider add: (universe newestPackageNamed: depName) ]
					ifFalse: [
						^errorBlock value: depName ] ] ] ] ].
	
	^newPackages