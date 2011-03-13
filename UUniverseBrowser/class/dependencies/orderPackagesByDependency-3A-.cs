orderPackagesByDependency: packages
	"return a collection of the specified packages such that, when possible, any dependencies of a package are ordered before that package"
	"The present algorithm is simple but slow..."
	| remainingPackages orderedPackages packagesToAdd |
	remainingPackages _ Set new.
	orderedPackages _ OrderedCollection new.
	remainingPackages addAll: packages.
	
	"each time through this loop, add to orderedPackages any packages whose dependencies are not in remainaingPackages"
	[	packagesToAdd := remainingPackages select: [ :p | p depends noneSatisfy: [ :depName | remainingPackages anySatisfy: [ :p2 | p2 name = depName ] ] ].
		packagesToAdd isEmpty not
	] whileTrue: [
		orderedPackages addAll: packagesToAdd.
		remainingPackages := remainingPackages difference: packagesToAdd ].
	
	orderedPackages addAll: remainingPackages.
	^orderedPackages
