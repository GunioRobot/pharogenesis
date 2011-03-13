doInstall
	| orderedPackages |
	self anyPackageSelected not ifTrue: [^self].
	orderedPackages := self orderPackagesByDependency: selectedPackageVersions.
	orderedPackages
		do: [ :p | 
				Utilities informUser: 'installing ', p printString
						during: [configuration installPackage: p] ].
	self initializeSelectedPackageVersions.
