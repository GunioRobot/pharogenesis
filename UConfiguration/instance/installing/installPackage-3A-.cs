installPackage: aPackage
	| matchingPackages |
	matchingPackages _ installedPackages select: [ :p | p name = aPackage name ].
	installedPackages removeAll: matchingPackages.
	aPackage install.
	installedPackages add: aPackage.
	